using APPROVAL.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPROVAL.Configurations
{
    public class MariaContextCreater
    {
        public async Task CreatAsync(MariaContext context, ILogger<MariaContextCreater> logger)
        {
            var policy = CreatePolicy(logger, nameof(MariaContextCreater));

            await policy.ExecuteAsync(async () =>
            {
                using (context)
                {
                    context.Database.Migrate();
                    await context.SaveChangesAsync();
                }
            });
        }


        private AsyncRetryPolicy CreatePolicy(ILogger<MariaContextCreater> logger, string prefix, int retries = 3)
        {
            string logDefine = "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}";

            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogWarning(exception, logDefine, prefix, exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }

    }
}

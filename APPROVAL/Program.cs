using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APPROVAL.Configurations;
using APPROVAL.Data;
using APPROVAL.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace APPROVAL
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;
        public static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            try
            {
                //Log.Information("Configuring web host ({ApplicationContext})...", AppName);
                host.MigrateDbContext<MariaContext>((context, services) =>
                {
                    var logger = services.GetService(typeof(ILogger<MariaContextCreater>));
                    new MariaContextCreater().CreatAsync(context, logger as ILogger<MariaContextCreater>).Wait();
                });

                //Log.Information("Starting web host ({ApplicationContext})...", AppName);

            }
            catch (Exception ex)
            {
                //Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
            }
            finally
            {
                //Log.CloseAndFlush();
                host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

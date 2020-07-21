using APPROVAL.Extentions;
using Elastic.Apm.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace APPROVAL
{
    public class Startup
    {
        private const string koCulture = "ko";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddConfig(Configuration)
                .AddLocalization(koCulture)
                .AddResource()
                .AddDbContext(Configuration)
                .AddMariaDbContext(Configuration)
                .AddRepository()
                .AddMapper()
                .AddApiVersion()
                .AddJson()
                .AddSwagger()
                .AddHttpContextAccessor();      // 사용자 지정 구성 요소에서 HttpContext 사용;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseApiVersioning();

            // app.UseAllElasticApm(Configuration);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1.0/swagger.json", "Approval API v1.0");
                c.SwaggerEndpoint($"/swagger/v2.0/swagger.json", "Approval API v2.0");
            });
        }
    }
}

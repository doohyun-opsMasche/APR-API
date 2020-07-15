using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APPROVAL.Configurations;
using APPROVAL.Data;
using APPROVAL.Models;
using APPROVAL.Services;
using APPROVAL.Services.Documents;
using AutoMapper;
using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using Swashbuckle.AspNetCore.Swagger;

namespace APPROVAL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region MSSQL DB 연결
            //DB Connection 처리
            //Docker 환경
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApprovalConnection")));
            #endregion 

            #region Maria DB 연결
            //Maria DB Connection 처리
            services.AddDbContext<MariaContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("MariaConnection"),
                    optionsBuilder =>
                    {
                        optionsBuilder.CharSet(CharSet.Utf8).CharSetBehavior(CharSetBehavior.AppendToAllAnsiColumns);
                    }
                );
            });
            #endregion 

            //Smilegate 통테 환경
            // services.AddDbContext<CommanderContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApprovalConnection")));

            //Repository 연결
            services.AddScoped<IDocumentsService, DocumentsService>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IFormFileGroupService, FormFileGroupService>();

            //Mapper 설졍            
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(Startup));

            //API Versioning
            services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            // NewtonsoftJson 설정
            services.AddControllers().AddNewtonsoftJson(s => s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "Approval API 1.0",
                    Description = "Approval API Version 1.0"
                });

                c.SwaggerDoc("v2.0", new OpenApiInfo
                {
                    Version = "v2.0",
                    Title = "Approval API version 2.0",
                    Description = "Approval API Version 2.0"
                });

                c.ResolveConflictingActions(a => a.First());
                c.OperationFilter<RemoveVersionFromParameter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();
            });
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

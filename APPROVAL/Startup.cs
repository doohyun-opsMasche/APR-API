using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APPROVAL.Data;
using AutoMapper;
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
            
            //DB Connection 처리
            //Docker 환경
            // services.AddDbContext<CommanderContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("CommanderConnection")));
            //Smilegate 통테 환경
            services.AddDbContext<CommanderContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ApprovalConnection")));

            //Repository 연결
            services.AddScoped<ICommanderRepo, SqlCommanderRepo>();

            //Mapper 설졍            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            //API Versioning
            services.AddApiVersioning(options => {
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

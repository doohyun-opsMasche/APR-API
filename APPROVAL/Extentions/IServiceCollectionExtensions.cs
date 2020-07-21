using APPROVAL.Configurations;
using APPROVAL.Data;
using APPROVAL.Services;
using APPROVAL.Services.Documents;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace APPROVAL.Extentions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// appSettings mapping
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
        {
            return services.Configure<AppSettings>(config);
        }

        /// <summary>
        /// 지역화 사용 구성
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="culture">디폴트 지역</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddLocalization(this IServiceCollection services, string culture)
        {
            return services.Configure<RequestLocalizationOptions>(options =>
             {
                 var supportedCultures = new[]
                 {
                    new CultureInfo(culture),
                    new CultureInfo("en"),
                    new CultureInfo("zh"),
                 };

                 options.DefaultRequestCulture = new RequestCulture(culture: culture, uiCulture: culture);
                 options.SupportedCultures = supportedCultures;
                 options.SupportedUICultures = supportedCultures;

                 options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
                 {
                    // My custom request culture logic
                    // 여기서 어떤 언어를 사용할지 선언을 하여 사용하도록 한다. 
                    // 쿠키나 설정 값에 의해 언어를 지정 할 수 있도록 함.
                    // 비동기로 호출하기에 아래와 같이 수정이 필요.
                    // return new ProviderCultureResult("ko");

                    // 쿠키나 설정 값에 의한 값 지정이 필요
                    return await new Task<ProviderCultureResult>(() => { return new ProviderCultureResult("en"); });
                 }));
             });
        }

        /// <summary>
        /// Resource 사용 구성
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddResource(this IServiceCollection services)
        {
            services.AddMvc().AddDataAnnotationsLocalization();
            return services.AddLocalization(options => options.ResourcesPath = "Resources");
        }

        /// <summary>
        /// DbContext 구성
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="sample">샘플 변수</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration config)
        {
            //services.AddDbContext<CommanderContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApprovalConnection")));
            return services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("ApprovalConnection")));
        }

        /// <summary>
        /// Maria DbContext 구성
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="sample">샘플 변수</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddMariaDbContext(this IServiceCollection services, IConfiguration config)
        {
            #region Maria DB 연결
            //Maria DB Connection 처리
            return services.AddDbContext<MariaContext>(options =>
            {
                options.UseMySql(config.GetConnectionString("MariaConnection"),
                    optionsBuilder =>
                    {
                        optionsBuilder.CharSet(CharSet.Utf8).CharSetBehavior(CharSetBehavior.AppendToAllAnsiColumns);
                    }
                );
            });
            #endregion 
        }

        /// <summary>
        /// Repository 구성 
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            //Repository 연결
            services.AddScoped<IDocumentsService, DocumentsService>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IFormFileGroupService, FormFileGroupService>();
            return services;
        }

        /// <summary>
        /// AutoMapper 구성 
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            //Mapper 설졍            
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services.AddAutoMapper(typeof(Startup));
        }

        /// <summary>
        /// API Versioning 구성
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            //API Versioning
            return services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });
        }

        /// <summary>
        /// Json 구성
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddJson(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(s => s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            return services;
        }

        /// <summary>
        /// Json 구성
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
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


    }
}

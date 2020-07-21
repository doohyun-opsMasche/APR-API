using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace APPROVAL.Controllers
{
    public class BaseController : ControllerBase
    {
        public readonly Common common;

        private readonly IOptionsMonitor<AppSettings> options;
        private readonly IStringLocalizerFactory factory;
        private readonly IHttpContextAccessor context;

        public BaseController(IOptionsMonitor<AppSettings> options, IStringLocalizerFactory factory, IHttpContextAccessor context)
        {
            common = new Common(options, factory, context);
        }
    }
}
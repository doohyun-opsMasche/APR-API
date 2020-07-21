using APPROVAL.Dtos.Forms;
using APPROVAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace APPROVAL.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "v1.0")]
    public class FormFileGroupController : BaseController
    {
        private readonly IFormFileGroupService _service;

        public FormFileGroupController(
            IFormFileGroupService service,
            IOptionsMonitor<AppSettings> options,
            IStringLocalizerFactory factory,
            IHttpContextAccessor context
            ) : base(options, factory, context)

        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(FormFileGroupCreate group)
        {
            return Ok(_service.Add(group));
        }


        [HttpPut]
        public IActionResult Update(FormFileGroupCreate group)
        {
            try
            {
                _service.Update(group);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetListAsync());
        }

        [HttpGet]
        public IActionResult Test([FromQuery] string type, string key)
        {
            return Ok(common.GetGlobalResource(type, key));
        }
    }
}
using APPROVAL.Dtos.Forms;
using APPROVAL.Models;
using APPROVAL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APPROVAL.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiExplorerSettings(GroupName = "v1.0")]
    public class FormFileGroupController : ControllerBase
    {
        private readonly IFormFileGroupService _service;
        public FormFileGroupController(IFormFileGroupService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(FormFileGroup group)
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
    }
}
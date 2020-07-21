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
    public class FormController : ControllerBase
    {
        private readonly IFormService _service;
       
        public FormController(
            IFormService service
            )
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(Form form)
        {
            return Ok(_service.Add(form));
        }


        [HttpPut]
        public IActionResult Update(Form form)
        {
            try
            {
                _service.Update(form);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Form form)
        {
            return Ok(await _service.GetListAsync(form));
        }

    }
}
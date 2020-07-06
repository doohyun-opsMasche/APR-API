using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace APPROVAL.Controllers
{
    //api ApprovalStatus
    /// <summary>
    /// default version : 1.0
    /// 각 버전별로 mapping 을 해야함
    /// </summary>

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "v1.0")]
    public class TestController: ControllerBase
    {
        private readonly IConfiguration _con;

        public TestController(IConfiguration con)
        {
            _con = con;
        }

        [HttpGet]
        public ActionResult Get()
        {
            string val = "";

            val = _con.GetSection("TestValue").GetSection("test").Value;

            return Ok(val);
        }
    }
}
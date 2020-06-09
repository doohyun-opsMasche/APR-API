using System.Collections.Generic;
using APPROVAL.Data;
using APPROVAL.Moedls;
using Microsoft.AspNetCore.Mvc;

namespace APPROVAL.Controllers
{
    //api commands
    // [Route("api/[controller]")]
    [Route("api/commands")]

    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        // Get api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        // Get api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return Ok(commandItem);
        }

    }
}
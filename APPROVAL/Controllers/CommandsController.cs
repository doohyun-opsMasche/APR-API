using System.Collections.Generic;
using APPROVAL.Data;
using APPROVAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace APPROVAL.Controllers
{
    //api commands
    // [Route("api/[controller]")]
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo repository)
        {
           _repository = repository; 
        }
        
        // Get api/commands
        [HttpGet, MapToApiVersion("1.0")]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        // Get api/commands/{id}
        [HttpGet("{id}"), MapToApiVersion("1.0")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return Ok(commandItem);
        }


        // [HttpGet("{id}"), MapToApiVersion("2.0")]
        // public ActionResult<Command> GetCommandByIds(int id)
        // {
        //     var commandItem = new string [] {"sample", "value2", "value3", "value4"};

        //     return Ok(commandItem);
        // }

    }
}
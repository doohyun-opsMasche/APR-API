using System.Collections.Generic;
using APPROVAL.Data;
using APPROVAL.Dtos;
using APPROVAL.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Get api/commands
        [HttpGet, MapToApiVersion("1.0")]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // Get api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById"), MapToApiVersion("1.0")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
        }

        // Post api/commands
        [HttpPost]
        public ActionResult<CommandCreateDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            //return 을 ReadDto 포맷으로 전달이 필요할 경우
            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { id = commandReadDto.id }, commandReadDto);
        }
    }
}
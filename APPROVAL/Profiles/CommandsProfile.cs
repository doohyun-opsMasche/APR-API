using AutoMapper;
using APPROVAL.Dtos;
using APPROVAL.Models;

namespace APPROVAL.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source -> Target 
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
        }
    }
}
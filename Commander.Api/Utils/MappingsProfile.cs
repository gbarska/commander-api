using AutoMapper;
using Commander.Api.Dtos;
using Commander.Logic.Models;

namespace Commander.Api.Utils
{
    public class MappingsProfiles : Profile
    {
       public MappingsProfiles()
       {
           CreateMap<Command, CommandReadDto>().ReverseMap(); 
           CreateMap<Command, CommandCreateDto>().ReverseMap(); 
       }
    }  
}
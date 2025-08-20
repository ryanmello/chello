using AutoMapper;
using backend.Models;
using backend.Models.DTO;

namespace backend
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<UserMessage, UserMessageCreateDTO>().ReverseMap();
        }
    }
}

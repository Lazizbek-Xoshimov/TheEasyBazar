using AutoMapper;
using TheEasyBazar.Domain.Entities;
using TheEasyBazar.Service.DTOs.Users;

namespace TheEasyBazar.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForCreationDto>().ReverseMap();
    }
}

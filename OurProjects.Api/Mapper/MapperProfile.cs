using AutoMapper;
using OurProjects.Api.DTO;
using OurProjects.Api.DTO.Identity;
using OurProjects.Data.Models;

namespace OurProjects.Api.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateCompanyDTO, Company>()
                .ForMember(dest => dest.CreatedAt, o => o.MapFrom(_ => DateTime.UtcNow));

            CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.UserName, o => o.MapFrom(src => src.Email))
                .ForMember(dest => dest.CreatedAt, o => o.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.EmailConfirmed, o => o.MapFrom(_ => true));
            CreateMap<User, ReadUserDTO>();

            CreateMap<CreateAreaDTO, Area>()
                .ForMember(dest => dest.CreatedAt, o => o.MapFrom(_ => DateTime.UtcNow));
            CreateMap<Area, ReadAreaDTO>();

            CreateMap<CreateTechnologyDTO, Technology>()
                .ForMember(dest => dest.CreatedAt, o => o.MapFrom(_ => DateTime.UtcNow));
            CreateMap<Technology, ReadTechnologyDTO>();



        }
    }
}

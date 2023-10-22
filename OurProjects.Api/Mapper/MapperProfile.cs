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

            CreateMap<User, ReadUserDTO>();
            CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.UserName, o => o.MapFrom(src => src.Email))
                .ForMember(dest => dest.CreatedAt, o => o.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.EmailConfirmed, o => o.MapFrom(_ => true));

            CreateMap<Area, ReadAreaDTO>();
            CreateMap<CreateAreaDTO, Area>()
                .ForMember(dest => dest.CreatedAt, o => o.MapFrom(_ => DateTime.UtcNow));

            CreateMap<Technology, ReadTechnologyDTO>();
            CreateMap<CreateTechnologyDTO, Technology>()
                .ForMember(dest => dest.CreatedAt, o => o.MapFrom(_ => DateTime.UtcNow));

            CreateMap<Project, ReadProjectDTO>();
            CreateMap<CreateProjectDTO, Project>()
                .ForMember(dest => dest.CreatedAt, o => o.MapFrom(_ => DateTime.UtcNow));

            CreateMap<ProjectTeamMember, ReadProjectTeamMemberDTO>();

            CreateMap<ProjectTechnology, ReadProjectTechnologyDTO>();



        }
    }
}

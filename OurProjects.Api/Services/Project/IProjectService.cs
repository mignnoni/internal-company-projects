using OurProjects.Api.DTO;
namespace OurProjects.Api.Services
{
    public interface IProjectService
    {
        Task Insert(CreateProjectDTO dto, Guid idCompany);
        Task<List<ReadProjectDTO>> GetAll(Guid idCompany);
        Task UpdateTechnologies(Guid idProject, List<UpdateProjectTechnologyDTO> technologies, Guid idCompany);
        Task UpdateTeamMembers(Guid idProject, List<UpdateProjectTeamMemberDTO> teamMembers, Guid idCompany);
    }
}

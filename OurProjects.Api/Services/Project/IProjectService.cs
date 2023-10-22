using OurProjects.Api.DTO;

namespace OurProjects.Api.Services
{
    public interface IProjectService
    {
        Task Insert(CreateProjectDTO dto);
        Task<List<ReadProjectDTO>> GetAll(Guid idCompany);
    }
}

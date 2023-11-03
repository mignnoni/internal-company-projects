using OurProjects.Api.DTO;

namespace OurProjects.Api.Services
{
    public interface IAreaService
    {
        Task Insert(CreateAreaDTO dto, Guid idCompany);
        Task<List<ReadAreaDTO>> GetAll(Guid idCompany);
        Task<ReadAreaDTO> GetById(Guid id, Guid idCompany);
        Task UpdateTitle(UpdatereaDTO dto, Guid idCompany);
        Task Delete(Guid id, Guid idCompany);
    }
}

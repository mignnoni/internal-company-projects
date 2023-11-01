using OurProjects.Api.DTO;
using OurProjects.Data.Models;

namespace OurProjects.Api.Services
{
    public interface IAreaService
    {
        Task Insert(CreateAreaDTO dto, Guid idCompany);
        Task<List<ReadAreaDTO>> GetAll(Guid idCompany);
    }
}

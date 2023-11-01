using OurProjects.Api.DTO;

namespace OurProjects.Api.Services
{
    public interface ITechnologyService
    {
        Task Insert(CreateTechnologyDTO dto, Guid idCompany);
        Task<List<ReadTechnologyDTO>> GetAll(Guid idCompany);
    }
}

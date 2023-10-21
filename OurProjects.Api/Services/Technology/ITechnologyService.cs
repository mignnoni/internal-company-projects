using OurProjects.Api.DTO;

namespace OurProjects.Api.Services
{
    public interface ITechnologyService
    {
        Task Insert(CreateTechnologyDTO dto);
        Task<List<ReadTechnologyDTO>> GetAll(Guid idCompany);
    }
}

using OurProjects.Api.DTO;
using OurProjects.Data.Models;

namespace OurProjects.Api.Services
{
    public interface ICompanyService
    {
        Task Insert(CreateCompanyDTO dto);
        Task<List<Company>> GetAll();
    }
}

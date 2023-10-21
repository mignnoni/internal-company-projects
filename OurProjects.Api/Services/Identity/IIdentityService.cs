using OurProjects.Api.DTO;
using OurProjects.Api.DTO.Identity;

namespace OurProjects.Api.Services.Identity
{
    public interface IIdentityService
    {
        Task CreateUser(CreateUserDTO dto);
        Task<List<ReadUserDTO>> GetByCompany(Guid idCompany);
    }
}

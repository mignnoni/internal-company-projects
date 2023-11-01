using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurProjects.Api.DTO;
using OurProjects.Api.DTO.Identity;
using OurProjects.Api.Helpers;
using OurProjects.Api.Services.Identity;

namespace OurProjects.Api.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService _service;

        public UserController(IIdentityService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Insert(CreateUserDTO dto)
        {
            try
            {
                await _service.CreateMember(dto, User.GetCompanyId());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<List<ReadUserDTO>> Get()
        {
            try
            {
                return await _service.GetByCompany(User.GetCompanyId());
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

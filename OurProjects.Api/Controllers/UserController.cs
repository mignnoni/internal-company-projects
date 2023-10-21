using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurProjects.Api.DTO;
using OurProjects.Api.DTO.Identity;
using OurProjects.Api.Services.Identity;

namespace OurProjects.Api.Controllers
{
    [AllowAnonymous]
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
                await _service.CreateUser(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<List<ReadUserDTO>> Get(Guid idCompany)
        {
            try
            {
                return await _service.GetByCompany(idCompany);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

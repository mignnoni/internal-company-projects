using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurProjects.Api.DTO;
using OurProjects.Api.DTO.Identity;
using OurProjects.Api.Helpers;
using OurProjects.Api.Services.Identity;
using OurProjects.Api.Services.JWT;

namespace OurProjects.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService _service;

        public UserController(IIdentityService service)
        {
            _service = service;
        }


        [Authorize(Roles = Roles.Manager)]
        [HttpPost("member")]
        public async Task InsertMember(CreateUserDTO dto)
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

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("manager")]
        public async Task InsertManager(CreateUserDTO dto)
        {
            try
            {
                await _service.CreateManager(dto, User.GetCompanyId());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize(Roles = Roles.Dev)]
        [HttpPost("admin")]
        public async Task InsertAdmin([FromQuery] Guid idCompany, [FromBody] CreateUserDTO dto)
        {
            try
            {
                await _service.CreateAdmin(dto, idCompany);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize(Roles = Roles.Admin)]
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

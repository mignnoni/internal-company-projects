using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurProjects.Api.DTO;
using OurProjects.Api.Helpers;
using OurProjects.Api.Services;
using OurProjects.Api.Services.JWT;

namespace OurProjects.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = Roles.Manager)]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService _service;

        public TechnologyController(ITechnologyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<ReadTechnologyDTO>> GetAll()
        {
            try
            {
                return await _service.GetAll(User.GetCompanyId());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task Insert(CreateTechnologyDTO dto)
        {
            try
            {
                await _service.Insert(dto, User.GetCompanyId());
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

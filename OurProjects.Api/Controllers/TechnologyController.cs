using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurProjects.Api.DTO;
using OurProjects.Api.Helpers;
using OurProjects.Api.Services;
using OurProjects.Api.Services.Identity;

namespace OurProjects.Api.Controllers
{
    [Authorize(Roles = Roles.Manager)]
    [ApiController]
    [Route("[controller]")]
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

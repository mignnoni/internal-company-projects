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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<ReadProjectDTO>> GetAll()
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
        public async Task Insert(CreateProjectDTO dto)
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

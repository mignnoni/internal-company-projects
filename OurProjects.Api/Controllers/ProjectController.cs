using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurProjects.Api.DTO;
using OurProjects.Api.Services;

namespace OurProjects.Api.Controllers
{
    [AllowAnonymous]
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
        public async Task<List<ReadProjectDTO>> GetAll(Guid idCompany)
        {
            try
            {
                return await _service.GetAll(idCompany);
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
                await _service.Insert(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

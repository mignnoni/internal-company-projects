using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurProjects.Api.DTO;
using OurProjects.Api.Helpers;
using OurProjects.Api.Services;
using OurProjects.Api.Services.JWT;

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

        [HttpPut("technologies")]
        public async Task UpdateTechnologies([FromQuery] Guid idProject, [FromBody] List<UpdateProjectTechnologyDTO> technologies)
        {
            try
            {
                await _service.UpdateTechnologies(idProject, technologies, User.GetCompanyId());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("teamMembers")]
        public async Task UpdateTeamMembers([FromQuery] Guid idProject, [FromBody] List<UpdateProjectTeamMemberDTO> teamMembers)
        {
            try
            {
                await _service.UpdateTeamMembers(idProject, teamMembers, User.GetCompanyId());
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurProjects.Api.DTO;
using OurProjects.Api.Helpers;
using OurProjects.Api.Services;
using OurProjects.Api.Services.JWT;

namespace OurProjects.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = Roles.Manager)]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _service;

        public AreaController(IAreaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<ReadAreaDTO>> GetAll()
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

        [HttpGet("{id}")]
        public async Task<ReadAreaDTO> GetById(Guid id)
        {
            try
            {
                return await _service.GetById(id, User.GetCompanyId());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task Insert(CreateAreaDTO dto)
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

        [HttpPatch("title")]
        public async Task UpdateTitle(UpdatereaDTO dto)
        {
            try
            {
                await _service.UpdateTitle(dto, User.GetCompanyId());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            try
            {
                await _service.Delete(id, User.GetCompanyId());
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

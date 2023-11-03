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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurProjects.Api.DTO;
using OurProjects.Api.Services;

namespace OurProjects.Api.Controllers
{
    [AllowAnonymous]
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
        public async Task<List<ReadAreaDTO>> GetAll(Guid idCompany)
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
        public async Task Insert(CreateAreaDTO dto)
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

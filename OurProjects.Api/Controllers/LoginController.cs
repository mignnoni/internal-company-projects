using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurProjects.Api.DTO.Identity;
using OurProjects.Api.Services.Identity;

namespace OurProjects.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IIdentityService _service;

        public LoginController(IIdentityService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<LoginResponseDTO> Login(LoginRequestDTO dto)
        {
            try
            {
                return await _service.Login(dto);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

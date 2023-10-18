using Microsoft.AspNetCore.Identity;
using OurProjects.Api.DTO;
using OurProjects.Api.DTO.Identity;
using OurProjects.Data.Models;

namespace OurProjects.Api.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public IdentityService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task CreateCompanyAdminUser(CreateUserDTO dto)
        {
            var identityUser = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                EmailConfirmed = true,
            };

            await _userManager.CreateAsync(identityUser, dto.Password);

        }

        public async Task CreateUser(CreateUserDTO dto)
        {
            var identityUser = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                EmailConfirmed = true,
            };

            await _userManager.CreateAsync(identityUser, dto.Password);
        }

        public async Task Login(LoginRequestDTO dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);
            if (!result.Succeeded)
                throw new ArgumentException("Erro ao fazer login");
        }
    }
}

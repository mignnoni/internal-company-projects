using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OurProjects.Api.DTO;
using OurProjects.Api.DTO.Identity;
using OurProjects.Data.Clients;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;

namespace OurProjects.Api.Services.Identity
{
    public class IdentityService : BaseService, IIdentityService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly UserRep _repo;

        public IdentityService(
            SignInManager<User> signInManager,
            UserManager<User> userManager, 
            IMapper mapper, 
            AppDbContext context) : base(context, mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _repo = new UserRep(_uow);
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
            try
            {
                var identityUser = _mapper.Map<User>(dto);

                var result = await _userManager.CreateAsync(identityUser, dto.Password);

                if (!result.Succeeded)
                    throw new ArgumentException(result.Errors.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ReadUserDTO>> GetByCompany(Guid idCompany)
        {
            try
            {
                return _mapper.Map<List<ReadUserDTO>>(await _repo.GetByCompany(idCompany));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Login(LoginRequestDTO dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);
            if (!result.Succeeded)
                throw new ArgumentException("Erro ao fazer login");
        }
    }
}

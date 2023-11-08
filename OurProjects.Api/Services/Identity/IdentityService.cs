using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OurProjects.Api.DTO;
using OurProjects.Api.DTO.Identity;
using OurProjects.Api.Services.JWT;
using OurProjects.Data.Clients;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;
using System.Security.Claims;

namespace OurProjects.Api.Services.Identity
{
    public class IdentityService : BaseService, IIdentityService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly UserRep _repo;
        private readonly IJWTService _jwtService;

        public IdentityService(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IMapper mapper,
            IJWTService jwtService,
            AppDbContext context) : base(context, mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtService = jwtService;
            _repo = new UserRep(_uow);
        }

        public async Task CreateAdmin(CreateUserDTO dto, Guid idCompany)
        {
            var user = await CreateUser(dto, idCompany);

            var roles = new List<string>
            {
                Roles.Dev,
                Roles.Admin,
                Roles.Manager,
                Roles.Member
            };

            await AddToRoles(user, roles);

            await AddClaims(user);
        }

        public async Task CreateManager(CreateUserDTO dto, Guid idCompany)
        {
            var user = await CreateUser(dto, idCompany);

            var roles = new List<string>
            {
                Roles.Manager,
                Roles.Member
            };

            await AddToRoles(user, roles);

            await AddClaims(user);
        }

        public async Task CreateMember(CreateUserDTO dto, Guid idCompany)
        {
            try
            {
                var user = await CreateUser(dto, idCompany);

                await AddToRoles(user, new List<string>() { Roles.Member });

                await AddClaims(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<User> CreateUser(CreateUserDTO dto, Guid idCompany)
        {
            try
            {
                var identityUser = _mapper.Map<User>(dto);
                identityUser.IdCompany = idCompany;

                var result = await _userManager.CreateAsync(identityUser, dto.Password);

                if (!result.Succeeded)
                    throw new ArgumentException(result.Errors.ToString());

                return identityUser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task AddToRoles(User user, IEnumerable<string> roles)
        {
            var result = await _userManager.AddToRolesAsync(user, roles);

            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.ToString());
        }

        private async Task AddClaims(User user)
        {
            var result = await _userManager.AddClaimsAsync(user, new List<Claim>
                {
                    new Claim(JwtClaims.IdCompany, user.IdCompany.ToString()),
                    new Claim(JwtClaims.Name, user.Name),
                    new Claim(JwtClaims.UserId, user.Id.ToString())
                });

            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.ToString());
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

        public async Task<LoginResponseDTO> Login(LoginRequestDTO dto)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);

                if (!result.Succeeded)
                    throw new ArgumentException("Erro ao fazer login");


                var user = await _userManager.FindByEmailAsync(dto.Email);

                if (user is null)
                    throw new NullReferenceException(nameof(user));

                var claims = await _userManager.GetClaimsAsync(user);
                var roles = await _userManager.GetRolesAsync(user);

                var token = _jwtService.CreateToken(claims.ToList(), roles.ToList());

                return new LoginResponseDTO(token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

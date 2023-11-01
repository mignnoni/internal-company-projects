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

        public async Task CreateCompanyAdminUser(CreateUserDTO dto, Guid idCompany)
        {
            var identityUser = _mapper.Map<User>(dto);
            identityUser.IdCompany = idCompany;

            var result = await _userManager.CreateAsync(identityUser, dto.Password);

            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.ToString());

            var roles = new List<string>
            {
                Roles.Admin,
                Roles.Manager,
                Roles.Member
            };

            result = await _userManager.AddToRolesAsync(identityUser, roles);

            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.ToString());

            result = await _userManager.AddClaimAsync(identityUser, new Claim(JwtClaims.IdCompany, idCompany.ToString()));

            if (!result.Succeeded)
                throw new ArgumentException(result.Errors.ToString());

        }

        public async Task CreateMember(CreateUserDTO dto, Guid idCompany)
        {
            try
            {
                var identityUser = _mapper.Map<User>(dto);
                identityUser.IdCompany = idCompany;

                var result = await _userManager.CreateAsync(identityUser, dto.Password);

                if (!result.Succeeded)
                    throw new ArgumentException(result.Errors.ToString());

                result = await _userManager.AddToRoleAsync(identityUser, Roles.Member);

                if (!result.Succeeded)
                    throw new ArgumentException(result.Errors.ToString());



                result = await _userManager.AddClaimsAsync(identityUser, new List<Claim>
                {
                    new Claim(JwtClaims.IdCompany, idCompany.ToString()),
                    new Claim(JwtClaims.Name, dto.Name),
                    new Claim(JwtClaims.UserId, identityUser.Id.ToString())
                });

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

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OurProjects.Api.Services.JWT
{
    public static class JwtClaims
    {
        public const string IdCompany = "idcompany";
        public const string UserId = ClaimTypes.NameIdentifier;
        public const string Jti = JwtRegisteredClaimNames.Jti;
        public const string Name = ClaimTypes.Name;
        public const string Iat = JwtRegisteredClaimNames.Iat;
    }
}

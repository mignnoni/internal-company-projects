using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OurProjects.Api.Services.JWT
{
    public class JWTService : IJWTService
    {
        private readonly JwtOptions _jwtOptions;

        public JWTService(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string CreateToken(List<Claim> claims, List<string> roles)
        {
            var token = new JwtSecurityToken(
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audience,
                    claims: GetClaims(claims, roles),
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddSeconds(_jwtOptions.TokenExpiration),
                    signingCredentials: _jwtOptions.SigningCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static List<Claim> GetClaims(List<Claim> claims, List<string> roles)
        {
            claims.AddJti();
            claims.AddIat();
            claims.AddRoles(roles);

            return claims;
        }
    }
}

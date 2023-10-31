using System.Security.Claims;

namespace OurProjects.Api.Services.JWT
{
    public static class JwtExtensions
    {
        public static void AddRoles(this List<Claim> claims, IEnumerable<string> roles)
        {
            if (roles != null && roles.Any())
            {
                claims.AddRange(roles.Select(s => new Claim(ClaimTypes.Role, s)));
            }
        }

        public static void AddIat(this List<Claim> claims)
        {
            claims.Add(new Claim(JwtClaims.Iat, DateTime.UtcNow.ToString()));
        }

        public static void AddJti(this List<Claim> claims)
        {
            claims.Add(new Claim(JwtClaims.Jti, Guid.NewGuid().ToString()));
        }
    }
}

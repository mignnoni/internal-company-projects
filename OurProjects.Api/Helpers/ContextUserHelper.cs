using OurProjects.Api.Services.JWT;
using System.Security.Claims;

namespace OurProjects.Api.Helpers
{
    public static class ContextUserHelper
    {
        public static Guid GetCompanyId(this ClaimsPrincipal claims)
        {
            var user = claims.FindFirstValue(JwtClaims.IdCompany);

            if (!string.IsNullOrEmpty(user))
            {
                _ = Guid.TryParse(user, out Guid idCompany);

                return idCompany;
            }

            return Guid.Empty;
        }
    }
}

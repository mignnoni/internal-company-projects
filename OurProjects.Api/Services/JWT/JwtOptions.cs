using Microsoft.IdentityModel.Tokens;

namespace OurProjects.Api.Services.JWT
{
    public class JwtOptions
    {
        public SigningCredentials SigningCredentials { get; set; }
        public int TokenExpiration { get; set; }
        public TokenValidationParameters TokenValidationParameters { get; set; }
    }
}

using Microsoft.IdentityModel.Tokens;

namespace OurProjects.Api.Services.JWT
{
    public class JwtOptions
    {
        public SigningCredentials SigningCredentials { get; set; }
        public int TokenExpiration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}

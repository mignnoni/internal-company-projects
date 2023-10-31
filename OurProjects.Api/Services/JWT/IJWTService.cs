using OurProjects.Data.Models;
using System.Security.Claims;

namespace OurProjects.Api.Services.JWT
{
    public interface IJWTService
    {
        string CreateToken(List<Claim> claims, List<string> roles);
    }
}

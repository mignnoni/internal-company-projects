using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OurProjects.Api.Services.JWT;
using System.Text;

namespace OurProjects.Api.Helpers
{
    public static class AuthenticationSetup
    {
        public static IServiceCollection AddJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConf = configuration.GetSection(nameof(JwtConf)).Get<JwtConf>();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConf.SecurityKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtConf.Issuer,
                ValidAudience = jwtConf.Audience,
                IssuerSigningKey = securityKey,
                ClockSkew = TimeSpan.Zero
            };

            services.Configure<JwtOptions>(options =>
            {
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
                options.TokenExpiration = jwtConf?.TokenExpiration ?? 0;
                options.Issuer = jwtConf?.Issuer ?? "";
                options.Audience = jwtConf?.Audience ?? "";
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
                options.IncludeErrorDetails = true;
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
            });

            return services;
        }
    }
}
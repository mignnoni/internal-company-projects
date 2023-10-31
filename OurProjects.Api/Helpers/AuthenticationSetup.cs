﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using OurProjects.Api.Services.JWT;
using System.Text;

namespace OurProjects.Api.Helpers
{
    public static class AuthenticationSetup
    {
        public static void AddJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConf = configuration.GetSection(nameof(JwtConf)).Get<JwtConf>();
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConf.SecurityKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
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
                options.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
                options.IncludeErrorDetails = true;
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy(JwtBearerDefaults.AuthenticationScheme, new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build());
            });
        }
    }
}
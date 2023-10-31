using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OurProjects.Api.Services;
using OurProjects.Api.Services.Identity;
using OurProjects.Api.Services.JWT;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;

namespace OurProjects.Api.Helpers
{
    public static class NativeInjectorConfig
    {

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ProjectsDb");

            services.AddDbContext<AppDbContext>(options =>
            {
                options
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services
                .AddIdentity<User, IdentityRole<Guid>>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole<Guid>>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IJWTService, JWTService>();

        }


    }
}

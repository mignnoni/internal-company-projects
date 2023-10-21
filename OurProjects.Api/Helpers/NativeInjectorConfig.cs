using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OurProjects.Api.Services;
using OurProjects.Api.Services.Identity;
using OurProjects.Data.Models;
using OurProjects.Data.Repository;

namespace OurProjects.Api.Helpers
{
    public static class NativeInjectorConfig
    {

        //public static IServiceCollection AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.Configure<PassportTokenConf>(configuration.GetSection(nameof(PassportTokenConf)));
        //    services.Configure<BearerTokenConf>(configuration.GetSection(nameof(BearerTokenConf)));
        //    services.Configure<WebPathConf>(configuration.GetSection(nameof(WebPathConf)));
        //    services.Configure<TotvsEndpointsConf>(configuration.GetSection(nameof(TotvsEndpointsConf)));
        //    services.Configure<EmailConf>(configuration.GetSection(nameof(EmailConf)));

        //    return services;
        //}

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ProjectsDb");

            services.AddDbContext<AppDbContext>(options =>
            {
                options
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services
                .AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<ITechnologyService, TechnologyService>();

        }

        //public static void AddServices(this IServiceCollection services)
        //{
        //    Injector.RegisterServices(services);
        //}

        //public static IServiceCollection AddJWT(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var bearerConf = configuration.GetSection(nameof(BearerTokenConf)).Get<BearerTokenConf>();
        //    var sigBearer = new BearerSigning(bearerConf.Key, bearerConf.Issuer, bearerConf.Audiences);
        //    services.AddSingleton(sigBearer);

        //    var passportConf = configuration.GetSection(nameof(PassportTokenConf)).Get<PassportTokenConf>();
        //    var sigPassport = new PassportSigning(passportConf.Key, passportConf.Issuer, passportConf.Audiences.Split(','));
        //    services.AddSingleton(sigPassport);

        //    services.AddAuthentication(o =>
        //    {
        //        o.DefaultAuthenticateScheme = AuthSchemas.Bearer;
        //        o.DefaultChallengeScheme = AuthSchemas.Bearer;
        //    })
        //    .AddJwtBearer(AuthSchemas.Bearer, jwtBearer =>
        //    {
        //        jwtBearer.RequireHttpsMetadata = true;
        //        jwtBearer.SaveToken = true;
        //        jwtBearer.TokenValidationParameters = sigBearer.TokenValidation;
        //    })
        //    .AddJwtBearer(AuthSchemas.Passport, jwtBearer =>
        //    {
        //        jwtBearer.RequireHttpsMetadata = true;
        //        jwtBearer.SaveToken = true;
        //        jwtBearer.TokenValidationParameters = sigPassport.TokenValidation;
        //    });

        //    services.AddAuthorization(auth =>
        //    {
        //        auth.AddPolicy(AuthSchemas.Bearer, new AuthorizationPolicyBuilder(AuthSchemas.Bearer)
        //            .RequireAuthenticatedUser()
        //            .Build());

        //        auth.AddPolicy(AuthSchemas.Passport, new AuthorizationPolicyBuilder(AuthSchemas.Passport)
        //            .RequireAuthenticatedUser()
        //            .Build());
        //    });

        //    return services;
        //}

    }
}

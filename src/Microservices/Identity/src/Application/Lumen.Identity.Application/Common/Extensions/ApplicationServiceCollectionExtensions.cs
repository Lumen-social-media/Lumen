using Lumen.Identity.Application.Common.Auth;
using Lumen.Identity.Application.Common.Auth.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lumen.Identity.Application.Common.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(ApplicationServiceCollectionExtensions).Assembly);
        });

        services.AddScoped<ClaimsFactory>();
        services.AddScoped<RefreshTokenGenerator>();
        services.AddScoped<JwtFactory>();
        services.AddScoped<TokenValidationParametersFactory>();
        services.AddScoped<PasswordHasher>();

        return services;
    }

    public static JwtOptions ConfigureJwtOptions(this IServiceCollection services, IConfiguration config)
    {
        var jwtOptions = new JwtOptions
        {
            Audience = config["Jwt:Audience"] ?? "localhost",
            Issuer = config["Jwt:Issuer"] ?? "localhost",
            ExpiresInMinutes = int.Parse(config["Jwt:ExpiresFromMinutes"] ?? "5"),
            SecretKey = config["Jwt:SecretKey"] ?? "default"
        };
        services.Configure<JwtOptions>(options =>
        {
            options.Audience = jwtOptions.Audience;
            options.Issuer = jwtOptions.Issuer;
            options.ExpiresInMinutes = jwtOptions.ExpiresInMinutes;
            options.SecretKey = jwtOptions.SecretKey;
        });

        return jwtOptions;
    }
}

using Lumen.Identity.Application.Common.Auth;
using Lumen.Identity.Application.Common.Auth.Jwt;
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
}

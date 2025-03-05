using Microsoft.Extensions.DependencyInjection;

namespace Lumen.Users.Application.Common.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ApplicationServiceCollectionExtensions).Assembly);
        });

        return services;
    }
}

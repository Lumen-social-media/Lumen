using Lumen.Identity.Infrastructure.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lumen.Identity.Infrastructure.Common.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, InfrastructureOptions options)
    {
        services.AddDbContext<LumenDbContext>(config =>
        {
            config.UseNpgsql(options.ConnectionString);
        });

        services.AddIdentity<InfrastructureUser, IdentityRole<int>>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<LumenDbContext>();

        return services;
    }
}

using Lumen.Identity.Application.User.Consumers;
using Lumen.Identity.Infrastructure.User;
using MassTransit;
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


        services.AddMassTransit(x =>
        {
            x.AddConsumers(typeof(UserCreateMessageConsumer).Assembly);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(options.RabbitMQHost, h =>
                {
                    h.Username(options.RabbitMQUserName);
                    h.Password(options.RabbitMQPassword);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}

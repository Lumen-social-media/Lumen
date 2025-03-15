using Lumen.Profile.Application.Common.EventBus;
using Lumen.Profile.Infrastructure.Aggregates.Users.Consumers;
using Lumen.Profile.Infrastructure.Aggregates.Users.Messages.UserRegistered;
using Lumen.Profile.Infrastructure.Common.EventBus;
using Lumen.Profile.UseCases.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Lumen.Profile.Infrastructure.Common.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, InfrastructureOptions options)
    {
        services.AddDbContext<LumenDbContext>(dbOptions =>
        {
            dbOptions.UseNpgsql(options.ConnectionString);
        });

        services.AddScoped<IApplicationContext, LumenDbContext>();
        services.AddScoped<IEventBus, RabbitMQEventBus>();

        return services;
    }

    public static IServiceCollection RegisterConsumers(this IServiceCollection services, InfrastructureOptions options)
    {
        services.AddScoped<IConsumer<UserRegisteredMessage>, UserRegisteredMessageConsumer>();

        return services;
    }

    public static IServiceCollection RegisterRabbitMQConnectionFactory(this IServiceCollection services, InfrastructureOptions options)
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = options.RabbitMQHost,
            UserName = options.RabbitMQUserName,
            Password = options.RabbitMQPassword
        };
        services.AddSingleton(connectionFactory);

        return services;
    }

    public static InfrastructureOptions ConfigureInfrastructureOptions(this IServiceCollection services, IConfiguration config)
    {
        var infrastructureOptions = new InfrastructureOptions
        {
            ConnectionString = config.GetConnectionString("PostgreSQL"),
            RedisHost = config.GetConnectionString("Redis"),
            RedisInstanceName = config.GetConnectionString("RedisInstanceName"),
            RabbitMQHost = config["RabbitMQ:Host"] ?? "localhost",
            RabbitMQPassword = config["RabbitMQ:PasswordHash"] ?? "guest",
            RabbitMQUserName = config["RabbitMQ:Username"] ?? "guest"
        };
        services.Configure<InfrastructureOptions>(options =>
        {
            options.ConnectionString = config.GetConnectionString("PostgreSQL");
            options.RedisHost = config.GetConnectionString("Redis");
            options.RedisInstanceName = config.GetConnectionString("RedisInstanceName");
            options.RabbitMQHost = config["RabbitMQ:Host"] ?? "localhost";
            options.RabbitMQPassword = config["RabbitMQ:PasswordHash"] ?? "guest";
            options.RabbitMQUserName = config["RabbitMQ:Username"] ?? "guest";
        });

        return infrastructureOptions;
    }
}

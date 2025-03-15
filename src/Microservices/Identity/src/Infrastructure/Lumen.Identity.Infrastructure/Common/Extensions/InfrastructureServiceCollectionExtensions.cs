using Lumen.Identity.Application.Common.Caching;
using Lumen.Identity.Application.Common.EventBus;
using Lumen.Identity.Application.Users.Repositories;
using Lumen.Identity.Infrastructure.Common.Caching;
using Lumen.Identity.Infrastructure.Common.EventBus;
using Lumen.Identity.Infrastructure.Users.Repositories;
using Lumen.Identity.UseCase.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Lumen.Identity.Infrastructure.Common.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, InfrastructureOptions options)
    {
        services.AddDbContext<LumenDbContext>(config =>
        {
            config.UseNpgsql(options.ConnectionString);
        });
        services.AddScoped<IApplicationDbContext, LumenDbContext>();

        services.AddScoped<IEventBus, RabbitMQEventBus>();
        services.RegisterRabbitMQConnectionFactory(options);

        services.AddStackExchangeRedisCache(cfg =>
        {
            cfg.Configuration = options.RedisHost;
            cfg.InstanceName = options.RedisInstanceName;
        });
        services.AddScoped<ICache, RedisDistributedCache>();
        services.AddScoped<IUserCachedRepository, UserCachedEfRepository>();


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

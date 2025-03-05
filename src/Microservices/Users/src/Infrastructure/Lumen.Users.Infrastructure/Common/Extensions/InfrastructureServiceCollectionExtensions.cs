using Lumen.Users.UseCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lumen.Users.Infrastructure.Common.Extensions;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, InfrastructureOptions options)
    {
        services.AddDbContext<LumenDbContext>(dbOptions =>
        {
            dbOptions.UseNpgsql(options.ConnectionString);
        });

        services.AddScoped<IApplicationContext, LumenDbContext>();

        //services.AddMassTransit(configure =>
        //{
        //    configure.AddConsumers(typeof(UserCreatedMessageConsumer).Assembly);

        //    configure.UsingRabbitMq((busContext, rabbitMqBusFactory) =>
        //    {
        //        rabbitMqBusFactory.Host(options.RabbitMQHost, conf =>
        //        {
        //            conf.Username(options.RabbitMQUserName);
        //            conf.Password(options.RabbitMQPassword);
        //        });

        //        rabbitMqBusFactory.ConfigureEndpoints(busContext);
        //    });
        //});

        return services;
    }
}

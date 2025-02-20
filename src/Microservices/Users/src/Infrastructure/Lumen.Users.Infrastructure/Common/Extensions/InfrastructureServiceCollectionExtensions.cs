using Lumen.Users.Application.Aggregates.User.Consumers;
using Lumen.Users.Domain.Aggregates.User.Repositories;
using Lumen.Users.Domain.Common.UnitOfWorks;
using Lumen.Users.Infrastructure.Aggregates.User.Repositories;
using MassTransit;
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

        services.AddMassTransit(configure =>
        {
            configure.AddConsumers(typeof(UserCreatedMessageConsumer).Assembly);

            configure.UsingRabbitMq((busContext, rabbitMqBusFactory) =>
            {
                rabbitMqBusFactory.Host(options.RabbitMQHost, conf =>
                {
                    conf.Username(options.RabbitMQUserName);
                    conf.Password(options.RabbitMQPassword);
                });

                rabbitMqBusFactory.ConfigureEndpoints(busContext);
            });
        });

        services.AddScoped<IEfReadonlyUnitOfWork, EfReadOnlyUnitOfWork>();
        services.AddScoped<IEfWriteOnlyUnitOfWork, EfWriteOnlyUnitOfWork>();

        services.AddScoped<IUserEfReadOnlyRepository, UserEfReadOnlyRepository>();
        //services.AddScoped<(IUserBoardEfReadOnlyRepository, >();
        //services.AddScoped<IUserEfReadOnlyRepository, UserEfReadOnlyRepository>();
        //services.AddScoped<IUserEfReadOnlyRepository, UserEfReadOnlyRepository>();
        //services.AddScoped<IUserEfReadOnlyRepository, UserEfReadOnlyRepository>();
        //services.AddScoped<IUserEfReadOnlyRepository, UserEfReadOnlyRepository>();

        services.AddScoped<IUserEfWriteOnlyRepository, UserEfWriteOnlyRepository>();
        //services.AddScoped<IUserEfReadOnlyRepository, UserEfReadOnlyRepository>();
        //services.AddScoped<IUserEfReadOnlyRepository, UserEfReadOnlyRepository>();
        //services.AddScoped<IUserEfReadOnlyRepository, UserEfReadOnlyRepository>();
        //services.AddScoped<IUserEfReadOnlyRepository, UserEfReadOnlyRepository>();
        return services;
    }
}

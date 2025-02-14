using FluentValidation;
using Lumen.Users.Application.Aggregates.User;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Lumen.Users.Application.Common.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(UserResponse).Assembly);
        });

        services.AddValidatorsFromAssembly(typeof(UserResponse).Assembly);
        services.AddMapster();

        return services;
    }

    public static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();
        var registers = config.Scan(Assembly.GetAssembly(typeof(UserResponse)) ?? Assembly.GetExecutingAssembly());
        config.Apply(registers);

        services.AddSingleton(config);
        services.AddSingleton<IMapper, ServiceMapper>();


        return services;
    }

}

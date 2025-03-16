using Lumen.Identity.Application.Common.Auth.Jwt;
using Lumen.Identity.Application.Common.Extensions;
using Microsoft.Extensions.Options;

namespace Lumen.Identity.RestApi.Common.Extensions;

public static class RestApiServiceCollectionExtensions
{
    public static IServiceCollection AddJwtBearerAuthentication(this IServiceCollection services, IConfiguration config)
    {
        var jwtOptions = services.ConfigureJwtOptions(config);
        services.AddAuthentication().AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParametersFactory(Options.Create(jwtOptions)).Create();
        });

        return services;
    }

    public static IServiceCollection AddPrometheus(this IServiceCollection services, IConfiguration config)
    {


        return services;
    }
}

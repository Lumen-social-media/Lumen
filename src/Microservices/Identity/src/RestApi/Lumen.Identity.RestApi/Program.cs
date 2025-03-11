using Lumen.Identity.Application.Common.Auth.Jwt;
using Lumen.Identity.Application.Common.Extensions;
using Lumen.Identity.Infrastructure.Common;
using Lumen.Identity.Infrastructure.Common.Extensions;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;

var jwtOptions = new JwtOptions
{
    Audience = config["Jwt:Audience"] ?? "localhost",
    Issuer = config["Jwt:Issuer"] ?? "localhost",
    ExpiresInMinutes = int.Parse(config["Jwt:ExpiresFromMinutes"] ?? "5"),
    SecretKey = config["Jwt:SecretKey"] ?? "default"
};

services.AddControllers();
services.AddOpenApi();
services.AddTransient(s => s.GetService<HttpContext>()!.User);
services.Configure<JwtOptions>(options =>
{
    options.Audience = jwtOptions.Audience;
    options.Issuer = jwtOptions.Issuer;
    options.ExpiresInMinutes = jwtOptions.ExpiresInMinutes;
    options.SecretKey = jwtOptions.SecretKey;
});

services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParametersFactory(Options.Create(jwtOptions)).Create();
});

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
services.AddInfrastructure(infrastructureOptions);
services.AddApplication();

#region Middlewares
var app = builder.Build();

app.UseCors(options =>
{
    options.WithOrigins(config.GetSection("Cors").Get<string[]>()!)
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(options => true);
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
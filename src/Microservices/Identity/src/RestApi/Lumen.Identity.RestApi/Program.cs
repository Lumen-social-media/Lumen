using Lumen.Identity.Application.Common.Auth.Jwt;
using Lumen.Identity.Application.Common.Extensions;
using Lumen.Identity.Infrastructure.Common;
using Lumen.Identity.Infrastructure.Common.Extensions;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;

var infrastructureOptions = new InfrastructureOptions
{
    ConnectionString = builder.Configuration.GetConnectionString("PostgreSQL"),
    RedisHost = config.GetConnectionString("Redis"),
    RedisInstanceName = config.GetConnectionString("RedisInstanceName"),
    RabbitMQHost = builder.Configuration["RabbitMQ:Host"] ?? "localhost",
    RabbitMQPassword = builder.Configuration["RabbitMQ:Password"] ?? "guest",
    RabbitMQUserName = builder.Configuration["RabbitMQ:Username"] ?? "guest"
};
services.AddInfrastructure(infrastructureOptions);
services.AddApplication();

var jwtOptions = new JwtOptions
{
    Audience = config["Jwt:Audience"] ?? "localhost",
    Issuer = config["Jwt:Issuer"] ?? "localhost",
    Expires = new DateTime().AddMinutes(double.Parse(config["Jwt:ExpiresFromMinutes"] ?? "5")),
    SecretKey = config["Jwt:SecretKey"] ?? "default"
};


services.AddControllers();
services.AddOpenApi();
services.AddTransient(s => s.GetService<HttpContext>()!.User);
services.Configure<JwtOptions>(options =>
{
    options = jwtOptions;
});

services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParametersFactory(Options.Create(jwtOptions)).Create();
});

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

using Lumen.Users.Application.Common.Extensions;
using Lumen.Users.Infrastructure.Common;
using Lumen.Users.Infrastructure.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddControllers();
services.AddOpenApi();

var infrastructureOptions = new InfrastructureOptions
{
    ConnectionString = configuration.GetConnectionString("PostgreSQL"),
    RabbitMQHost = configuration["RabbitMQ:Host"]!,
    RabbitMQPassword = configuration["RabbitMQ:Password"]!,
    RabbitMQUserName = configuration["RabbitMQ:UserName"]!
};

services.AddApplication();
services.AddInfrastructure(infrastructureOptions);
services.AddTransient(s => s.GetService<HttpContext>()!.User);

var app = builder.Build();

app.UseCors(options =>
{
    options.WithOrigins(configuration.GetSection("Cors").Get<string[]>()!)
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(options => true);
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

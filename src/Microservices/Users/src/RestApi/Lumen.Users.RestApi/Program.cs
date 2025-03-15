using Lumen.Profile.Application.Common.Extensions;
using Lumen.Profile.Infrastructure.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;

services.AddControllers();
services.AddOpenApi();

services.AddApplication();

var infrastructureOptions = services.ConfigureInfrastructureOptions(config);
services.AddInfrastructure(infrastructureOptions);

services.AddTransient(s => s.GetService<HttpContext>()!.User);

var app = builder.Build();

app.UseCors(options =>
{
    options.WithOrigins(config.GetSection("Cors").Get<string[]>()!)
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

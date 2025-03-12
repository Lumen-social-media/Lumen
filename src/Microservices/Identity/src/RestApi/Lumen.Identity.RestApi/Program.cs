using Lumen.Identity.Application.Common.Auth.Jwt;
using Lumen.Identity.Application.Common.Extensions;
using Lumen.Identity.Infrastructure.Common.Extensions;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;

services.AddControllers();
services.AddOpenApi();
services.AddTransient(s => s.GetService<HttpContext>()!.User);

var jwtOptions = services.ConfigureJwtOptions(config);
services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParametersFactory(Options.Create(jwtOptions)).Create();
});

var infrastructureOptions = services.ConfigureInfrastructureOptions(config);
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
using Lumen.Identity.Infrastructure.Common;
using Lumen.Identity.Infrastructure.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var infrastructureOptions = new InfrastructureOptions
{
    ConnectionString = builder.Configuration.GetConnectionString("PostgreSQL"),
    RabbitMQHost = builder.Configuration["RabbitMQ:Host"] ?? "localhost",
    RabbitMQPassword = builder.Configuration["RabbitMQ:Password"] ?? "guest",
    RabbitMQUserName = builder.Configuration["RabbitMQ:Username"] ?? "guest"
};

builder.Services.AddInfrastructure(infrastructureOptions);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

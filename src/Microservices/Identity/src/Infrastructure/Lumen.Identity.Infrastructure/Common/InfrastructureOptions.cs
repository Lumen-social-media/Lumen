namespace Lumen.Identity.Infrastructure.Common;

public sealed class InfrastructureOptions
{
    public string? ConnectionString { get; set; }
    
    public required string RabbitMQHost { get; set; }
    public required string RabbitMQUserName { get; set; }
    public required string RabbitMQPassword { get; set; }
}

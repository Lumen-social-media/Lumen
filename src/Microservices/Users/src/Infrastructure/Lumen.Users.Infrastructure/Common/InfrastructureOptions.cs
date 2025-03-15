namespace Lumen.Profile.Infrastructure.Common;

public sealed class InfrastructureOptions
{
    public string? ConnectionString { get; set; }
    public string? RedisHost { get; set; }
    public string? RedisInstanceName { get; set; }

    public required string RabbitMQHost { get; set; }
    public required string RabbitMQUserName { get; set; }
    public required string RabbitMQPassword { get; set; }
}

using Lumen.Profile.Application.Common.EventBus;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;

namespace Lumen.Profile.Infrastructure.Common.EventBus;

public sealed class RabbitMQEventBus(IOptions<InfrastructureOptions> infrastructureOptions) : IEventBus
{
    public async Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
    {
        var factory = new ConnectionFactory()
        {
            HostName = infrastructureOptions.Value.RabbitMQHost,
            Password = infrastructureOptions.Value.RabbitMQPassword
        };

        using var connection = await factory.CreateConnectionAsync(cancellationToken);
        using var channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);
        await channel.QueueDeclareAsync(queue: typeof(TMessage).Name,
                                        durable: true,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null,
                                        cancellationToken: cancellationToken);

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        await channel.BasicPublishAsync(exchange: "User",
                                        routingKey: "",
                                        body: body,
                                        cancellationToken: cancellationToken);
    }
}

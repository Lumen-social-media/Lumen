using Lumen.Identity.Application.Common.EventBus;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Lumen.Identity.Infrastructure.Common.EventBus;

public sealed class RabbitMQEventBus(IConnectionFactory connectionFactory) : IEventBus
{
    public async Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
    {
        using var connection = await connectionFactory.CreateConnectionAsync(cancellationToken);
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

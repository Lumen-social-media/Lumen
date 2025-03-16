using Lumen.Identity.Application.Common.EventBus;
using Lumen.Identity.UseCase.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Lumen.Identity.Infrastructure.Users.Consumers;

public abstract class ConsumerBase<TMessage>(IConnectionFactory connectionFactory) : IConsumer<TMessage> where TMessage : class
{
    public async Task Consume(TMessage message, CancellationToken cancellationToken = default)
    {
        using var connection = await connectionFactory.CreateConnectionAsync(cancellationToken);
        using var channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);

        var messageTypeName = typeof(TMessage).Name;
        await channel.QueueDeclareAsync(messageTypeName, cancellationToken: cancellationToken);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += Consumer_ReceivedAsync;

        await channel.BasicConsumeAsync(messageTypeName, false, consumer, cancellationToken: cancellationToken);
    }

    public abstract Task Consumer_ReceivedAsync(object sender, BasicDeliverEventArgs @event);
}

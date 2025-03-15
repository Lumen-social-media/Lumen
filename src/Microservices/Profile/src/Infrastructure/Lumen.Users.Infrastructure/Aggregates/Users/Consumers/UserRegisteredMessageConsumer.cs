using Lumen.Profile.Infrastructure.Aggregates.Users.Messages.UserRegistered;
using Lumen.Profile.Infrastructure.Aggregates.Users.Messages.UserRegistered.Mappers.Extensions;
using Lumen.Profile.Infrastructure.Common.EventBus;
using Lumen.Profile.UseCases.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;

namespace Lumen.Profile.Infrastructure.Aggregates.Users.Consumers;

public sealed class UserRegisteredMessageConsumer(IApplicationContext dbContext, IConnectionFactory connectionFactory) : IConsumer<UserRegisteredMessage>
{
    public async Task ConsumeAsync(CancellationToken cancellationToken = default)
    {
        using var connection = await connectionFactory.CreateConnectionAsync(cancellationToken);
        using var channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);
        
        await channel.QueueDeclareAsync(queue: nameof(UserRegisteredMessage), durable: false, exclusive: false, autoDelete: false, arguments: null, cancellationToken: cancellationToken);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (model, ea) =>
        {
            var body = ea.Body;
            var message = JsonSerializer.Deserialize<UserRegisteredMessage>(body.ToArray());

            var user = message!.ToUser();

            await dbContext.Users.AddAsync(user, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        };

        await channel.BasicConsumeAsync(queue: "User", autoAck: true, consumer: consumer, cancellationToken);
    }
}

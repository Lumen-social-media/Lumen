using Lumen.Identity.Application.Common.EventBus;
using Lumen.Identity.Infrastructure.Users.Consumers.Messages;
using Lumen.Identity.UseCase.Common;
using Lumen.Identity.UseCase.Users.Extensions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;

namespace Lumen.Identity.Infrastructure.Users.Consumers;

public sealed class UserDeletedMessageConsumer(IConnectionFactory connectionFactory, IApplicationDbContext context) : ConsumerBase<UserDeletedMessage>(connectionFactory)
{
    public override async Task Consumer_ReceivedAsync(object sender, BasicDeliverEventArgs @event)
    {
        var userDeletedMessage = JsonSerializer.Deserialize<UserDeletedMessage>(@event.Body.ToArray());

        await context.Users.DeleteByIdAsync(userDeletedMessage!.Id, @event.CancellationToken);
        await context.SaveChangesAsync(@event.CancellationToken);
    }
}

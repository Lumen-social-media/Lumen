using Lumen.Identity.Application.Common.EventBus;
using Lumen.Identity.Infrastructure.Users.Consumers.Messages;
using Lumen.Identity.Infrastructure.Users.Consumers.Messages.Mappers.Extensions;
using Lumen.Identity.UseCase.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;

namespace Lumen.Identity.Infrastructure.Users.Consumers;

public sealed class UserUpdatedMessageConsumer(IConnectionFactory connectionFactory, IApplicationDbContext context) : ConsumerBase<UserUpdatedMessage>(connectionFactory)
{
    public override async Task Consumer_ReceivedAsync(object sender, BasicDeliverEventArgs @event)
    {
        var userUpdatedMessage = JsonSerializer.Deserialize<UserUpdatedMessage>(@event.Body.ToArray());
        var user = userUpdatedMessage.ToUser();

        context.Users.Update(user);
        await context.SaveChangesAsync(@event.CancellationToken);
    }
}

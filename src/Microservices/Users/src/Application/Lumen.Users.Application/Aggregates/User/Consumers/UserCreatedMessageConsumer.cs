using Lumen.Common.Messages.User;
using MassTransit;

namespace Lumen.Users.Application.Aggregates.User.Consumers;

public sealed class UserCreatedMessageConsumer : IConsumer<UserCreatedMessage>
{
    public Task Consume(ConsumeContext<UserCreatedMessage> context)
    {
        throw new NotImplementedException();
    }
}

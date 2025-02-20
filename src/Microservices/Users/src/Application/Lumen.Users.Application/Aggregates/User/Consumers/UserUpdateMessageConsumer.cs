using Lumen.Common.Messages.User;
using MassTransit;

namespace Lumen.Users.Application.Aggregates.User.Consumers;

public sealed class UserUpdateMessageConsumer : IConsumer<UserUpdatedMessage>
{
    public Task Consume(ConsumeContext<UserUpdatedMessage> context)
    {
        throw new NotImplementedException();
    }
}

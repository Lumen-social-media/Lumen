using Lumen.Identity.Application.Common.MessageBroker;
using MassTransit;

namespace Lumen.Identity.Application.User.Consumers;

public sealed class UserCreateMessageConsumer 
{
    public Task Consume<TMessage>(TMessage message)
    {
        throw new NotImplementedException();
    }
}

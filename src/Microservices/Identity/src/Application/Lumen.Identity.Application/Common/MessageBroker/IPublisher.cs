namespace Lumen.Identity.Application.Common.MessageBroker;

public interface IPublisher
{
    public Task Publish<TMessage>(TMessage message, CancellationToken cancellationToken = default);
}

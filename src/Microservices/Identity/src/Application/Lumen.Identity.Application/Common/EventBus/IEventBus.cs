namespace Lumen.Identity.Application.Common.EventBus;

public interface IEventBus
{
    public Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default);
}

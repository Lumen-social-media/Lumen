namespace Lumen.Identity.Application.Common.EventBus;

public interface IConsumer<TMessage> where TMessage : class
{
    public Task Consume(TMessage message, CancellationToken cancellationToken = default);
}

namespace Lumen.Profile.Infrastructure.Common.EventBus;

public interface IConsumer<TMessage>
{
    public Task ConsumeAsync(CancellationToken cancellationToken = default);
}

using Lumen.Profile.Infrastructure.Aggregates.Users.Messages.UserRegistered;
using Lumen.Profile.Infrastructure.Common.EventBus;

namespace Lumen.Profile.RestApi.BackgroundServices;

public sealed class UserRegisteredConsumerBackgroundService(IConsumer<UserRegisteredMessage> consumer) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await consumer.ConsumeAsync(stoppingToken);
    }
}

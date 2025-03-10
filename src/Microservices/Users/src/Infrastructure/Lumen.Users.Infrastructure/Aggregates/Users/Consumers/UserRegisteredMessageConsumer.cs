using Lumen.Common.Messages.User;
using Lumen.Users.Domain.Aggregates.Users;
using Lumen.Users.Domain.Aggregates.Users.Dtos;
using Lumen.Users.UseCases;
using Mapster;
using MassTransit;

namespace Lumen.Users.Infrastructure.Aggregates.Users.Consumers;

public sealed class UserRegisteredMessageConsumer(IApplicationContext dbContext) : IConsumer<UserRegisteredMessage>
{
    public async Task Consume(ConsumeContext<UserRegisteredMessage> context)
    {
        var user = User.Create(context.Message.Adapt<CreateUserDto>());

        await dbContext.Users.AddAsync(user, context.CancellationToken);
        await dbContext.SaveChangesAsync(context.CancellationToken);
    }
}

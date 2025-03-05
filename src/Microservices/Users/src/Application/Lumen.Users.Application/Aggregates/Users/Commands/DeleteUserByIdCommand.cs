using Lumen.Users.UseCases;
using Mapster;

namespace Lumen.Users.Application.Aggregates.Users.Commands;

public sealed class DeleteUserByIdCommand : ICommand<UserResponse>
{
    public required int Id { get; set; }
}

public sealed class DeleteUserByIdCommandHandler(IApplicationContext context) : ICommandHandler<DeleteUserByIdCommand, UserResponse>
{
    public async Task<UserResponse> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
    {
        var user = await context.Users.FindAsync([command.Id], cancellationToken)
            ?? throw new NullReferenceException("");

        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);

        var response = user.Adapt<UserResponse>();

        return response;
    }
}

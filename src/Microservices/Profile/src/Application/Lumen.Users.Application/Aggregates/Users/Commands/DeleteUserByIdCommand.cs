using Lumen.Profile.Application.Aggregates.Users.Exceptions;
using Lumen.Profile.Application.Aggregates.Users.Mappers.Extensions;
using Lumen.Profile.Application.Common;
using Lumen.Profile.UseCases.Aggregates.Users.Extensions;
using Lumen.Profile.UseCases.Common;

namespace Lumen.Profile.Application.Aggregates.Users.Commands;

public sealed record DeleteUserByIdCommand : ICommand<UserResponse>
{
    public required Guid Id { get; set; }
}

public sealed class DeleteUserByIdCommandHandler(IApplicationContext context) : ICommandHandler<DeleteUserByIdCommand, UserResponse>
{
    public async Task<UserResponse> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
    {
        var user = await context.Users.DeleteByIdAsync(command.Id, cancellationToken)
            ?? throw new UserNotFoundException(command.Id);
        
        return user.ToResponse();
    }
}

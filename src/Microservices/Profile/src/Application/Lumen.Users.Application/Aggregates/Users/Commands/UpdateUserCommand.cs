using Lumen.Profile.Application.Aggregates.Users.Exceptions;
using Lumen.Profile.Application.Common;
using Lumen.Profile.UseCases.Aggregates.Users.Extensions;
using Lumen.Profile.UseCases.Common;

namespace Lumen.Profile.Application.Aggregates.Users.Commands;

public sealed class UpdateUserCommand : ICommand<UserResponse>
{
    public required Guid Id { get; set; }
}

public sealed class UpdateUserCommandHandler(IApplicationContext context) : ICommandHandler<UpdateUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await context.Users.FindByIdAsync(command.Id, cancellationToken)
            ?? throw new UserNotFoundException(command.Id);



        throw new NotImplementedException();
    }
}
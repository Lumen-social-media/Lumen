using FluentValidation;
using Lumen.Users.Application.Common;

namespace Lumen.Users.Application.Aggregates.User.Commands;

public sealed class CreateUserCommand : ICommand<UserResponse>
{

}

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {

    }
}


public sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserResponse>
{
    public Task<UserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
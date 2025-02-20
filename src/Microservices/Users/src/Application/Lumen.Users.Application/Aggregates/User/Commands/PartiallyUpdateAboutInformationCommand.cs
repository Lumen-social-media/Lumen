using FluentValidation;
using Lumen.Users.Application.Common;

namespace Lumen.Users.Application.Aggregates.User.Commands;

public sealed class PartiallyUpdateAboutInformationCommand : ICommand<UserResponse>
{

}

public sealed class PartiallyUpdateAboutInformationCommandValidator : AbstractValidator<PartiallyUpdateAboutInformationCommand>
{
    public PartiallyUpdateAboutInformationCommandValidator()
    {

    }
}

public sealed class PartiallyUpdateAboutInformationCommandHandler
    : ICommandHandler<PartiallyUpdateAboutInformationCommand, UserResponse>
{
    public Task<UserResponse> Handle(PartiallyUpdateAboutInformationCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
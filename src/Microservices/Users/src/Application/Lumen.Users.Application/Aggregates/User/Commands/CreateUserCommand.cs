using FluentValidation;
using Lumen.Users.Application.Aggregates.User.Exceptions;
using Lumen.Users.Application.Common;
using Lumen.Users.Application.Common.Extensions;
using Lumen.Users.Domain.Aggregates.User;
using Lumen.Users.Domain.Common.UnitOfWorks;
using MapsterMapper;
using System.Security.Claims;

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


public sealed class CreateUserCommandHandler(IEfWriteOnlyUnitOfWork Uof,
                                             ClaimsPrincipal CurrentUser,
                                             IMapper mapper) : ICommandHandler<CreateUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (!CurrentUser.IsAdmin())
            throw new UserNotAdminUnauthorizedAccessException("Only administrator can create user.");

        UserEntity user = mapper.Map<UserEntity>(command);

        UserEntity? result = await Uof.Users.AddAsync(user, cancellationToken);
        await Uof.SaveChangesAsync(cancellationToken);

        UserResponse response = mapper.Map<UserResponse>(result!);

        return response;
    }
}
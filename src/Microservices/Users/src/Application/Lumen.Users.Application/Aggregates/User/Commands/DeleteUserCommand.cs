using Lumen.Users.Application.Aggregates.User.Exceptions;
using Lumen.Users.Application.Common;
using Lumen.Users.Domain.Aggregates.User;
using Lumen.Users.Domain.Common.UnitOfWorks;
using MapsterMapper;
using System.Security.Claims;

namespace Lumen.Users.Application.Aggregates.User.Commands;

public sealed class DeleteUserCommand : ICommand<UserResponse>
{
    public required int UserId { get; set; }
}

public sealed class DeleteUserCommmandHandler(IEfWriteOnlyUnitOfWork writeOnlyUoW,
                                              IEfReadonlyUnitOfWork readonlyUnitOfWork,
                                              ClaimsPrincipal currentUser,
                                              IMapper mapper) : ICommandHandler<DeleteUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        UserEntity? user = await writeOnlyUoW.Users.DeleteByIdAsync(command.UserId, cancellationToken)
            ?? throw new UserNotFoundException(command.UserId);

        var response = mapper.Map<UserResponse>(user);

        return response;
    }
}

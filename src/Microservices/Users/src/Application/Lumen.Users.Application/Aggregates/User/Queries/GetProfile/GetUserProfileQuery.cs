using Lumen.Users.Application.Aggregates.User.Exceptions;
using Lumen.Users.Application.Aggregates.User.Post;
using Lumen.Users.Application.Common;
using Lumen.Users.Application.Common.Extensions;
using Lumen.Users.Domain.Aggregates.User;
using Lumen.Users.Domain.Common.UnitOfWorks;
using MapsterMapper;
using System.Security.Claims;

namespace Lumen.Users.Application.Aggregates.User.Queries.GetProfile;

public sealed class GetUserProfileQuery : IQuery<GetUserProfileQueryResponse>
{
    public required int UserId { get; set; }
}

public sealed class GetUserProfileQueryResponse
{
    public required UserResponse Profile { get; set; }
    public required IEnumerable<PostResponse> Posts { get; set; }
}

public sealed class GetUserProfileQueryHandler(IEfReadonlyUnitOfWork uof,
                                               IMapper mapper,
                                               ClaimsPrincipal CurrentUser) : IQueryHandler<GetUserProfileQuery, GetUserProfileQueryResponse>
{
    public async Task<GetUserProfileQueryResponse> Handle(GetUserProfileQuery query, CancellationToken cancellationToken)
    {
        UserEntity userFromDatabase = await uof.Users.FindByIdAsync(query.UserId, cancellationToken)
            ?? throw new UserNotFoundException(query.UserId);

        if (CurrentUser.IsAdmin())
            return await GetUserProfile(userFromDatabase, cancellationToken);

        if (!userFromDatabase.HasPublicProfile)
            throw new UnauthorizedAccessException("User's profile not public.");

        // if not authenticated and user's profile hidden from unregistered users
        if (CurrentUser.IsAuthenticated() && userFromDatabase.OnlyRegisteredUsersCanViewProfile)
            throw new UnauthorizedAccessException("Only registered users can view this profile.");

        return await GetUserProfile(userFromDatabase, cancellationToken);
    }

    private async Task<GetUserProfileQueryResponse> GetUserProfile(UserEntity user, CancellationToken cancellationToken = default)
    {
        var userId = user.Id;
        var userFromDatabase = await uof.Users.FindByIdAsync(userId, cancellationToken)
            ?? throw new UserNotFoundException(userId);

        var posts = await uof.Users.GetUserPosts(userId, cancellationToken);

        var response = new GetUserProfileQueryResponse
        {
            Profile = mapper.Map<UserResponse>(userFromDatabase),
            Posts = mapper.Map<IEnumerable<PostResponse>>(posts)
        };

        return response;
    }
}

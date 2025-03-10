using Lumen.Users.Application.Aggregates.Users.Entities.Posts;
using Lumen.Users.Application.Common.Extensions;
using Lumen.Users.Domain.Aggregates.Users;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Users.Domain.Aggregates.Users.ValueObjects;
using Lumen.Users.UseCases;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Lumen.Users.Application.Aggregates.Users.Queries;

public sealed record GetUserProfileQuery : IQuery<GetUserProfileQueryResponse>
{
    public required UserId UserId { get; set; }
}

public sealed record GetUserProfileQueryResponse
{
    public required UserResponse User { get; set; }
    public IEnumerable<PostResponse> Posts { get; set; } = new List<PostResponse>();
}

public sealed class GetUserProfileQueryHandler(IApplicationContext context, ClaimsPrincipal CurrentUser)
    : IQueryHandler<GetUserProfileQuery, GetUserProfileQueryResponse>
{
    public async Task<GetUserProfileQueryResponse> Handle(GetUserProfileQuery query, CancellationToken cancellationToken)
    {
        if (!CurrentUser.IsAuthenticated())
            throw new UnauthorizedAccessException("Only registered users can get profile.");

        var response = await GetProfileAsync(query, cancellationToken);

        if (CurrentUser.IsAdmin())
        {
            return response;
        }

        var idOfCurrentUser = UserId.Create(CurrentUser.ExtractId()!.Value);
        if (!response.User.HasPublicProfile && idOfCurrentUser != query.UserId)
        {
            throw new UnauthorizedAccessException("User profile is not public.");
        }

        return response;
    }

    public async Task<GetUserProfileQueryResponse> GetProfileAsync(GetUserProfileQuery query, CancellationToken cancellationToken)
    {
        var user = await GetUser(query, cancellationToken);
        var posts = await GetPostsAsync(query, cancellationToken);

        var userResponse = user.Adapt<UserResponse>();
        var postsResponse = posts.Adapt<IEnumerable<PostResponse>>();

        var response = new GetUserProfileQueryResponse { User = userResponse, Posts = postsResponse };

        return response;
    }

    public async Task<User?> GetUser(GetUserProfileQuery query, CancellationToken cancellationToken)
    {
        var user = await context.Users.FindAsync([query.UserId], cancellationToken);

        return user;
    }

    public async Task<IEnumerable<Post>> GetPostsAsync(GetUserProfileQuery query, CancellationToken cancellationToken)
    {
        var posts = await context.Posts
            .Where(p => p.OwnerId == query.UserId)
            .ToListAsync(cancellationToken);

        return posts;
    }
}
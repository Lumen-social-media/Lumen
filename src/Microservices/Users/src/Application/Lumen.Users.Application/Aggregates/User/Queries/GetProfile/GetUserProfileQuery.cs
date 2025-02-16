using Lumen.Users.Application.Aggregates.User.Post;
using Lumen.Users.Application.Common;
using Lumen.Users.Application.Common.Extensions;
using Lumen.Users.Domain.Common.UnitOfWorks;
using System.Security.Claims;

namespace Lumen.Users.Application.Aggregates.User.Queries.GetProfile;

public sealed class GetUserProfileQuery : IQuery<GetUserProfileQueryResponse>
{
    public required ClaimsPrincipal User { get; set; }
}

public sealed class GetUserProfileQueryResponse
{
    public required UserResponse Profile { get; set; }
    public required IEnumerable<PostResponse> UserPosts { get; set; }
}

public sealed class GetUserProfileQueryHandler(IEfReadonlyUnitOfWork uof) : IQueryHandler<GetUserProfileQuery, GetUserProfileQueryResponse>
{
    public Task<GetUserProfileQueryResponse> Handle(GetUserProfileQuery query, CancellationToken cancellationToken)
    {
        var userId = query.User.FindUserId();



        throw new NotImplementedException();
    }
}

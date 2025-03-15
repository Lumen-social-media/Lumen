using Lumen.Profile.Application.Common;
using Lumen.Profile.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Profile.UseCases.Common;
using Lumen.Profile.Domain.Aggregates.Users;

namespace Lumen.Profile.Application.Aggregates.Users.Queries;

public sealed record GetUserProfileQuery : IQuery<GetUserProfileQueryResponse>
{
    public required Guid UserId { get; set; }
}

public sealed record GetUserProfileQueryResponse
{
    public required User User { get; set; }
    public required IEnumerable<Post> Posts { get; set; }
}

public sealed class GetUserProfileQueryHandler : IQueryHandler<GetUserProfileQuery, GetUserProfileQueryResponse>
{
    private readonly IApplicationContext _context;

    public GetUserProfileQueryHandler(IApplicationContext context)
    {
        _context = context;
    }

    public async Task<GetUserProfileQueryResponse> Handle(GetUserProfileQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
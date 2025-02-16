using Lumen.Users.Application.Common;
using Lumen.Users.Domain.Common.UnitOfWorks;

namespace Lumen.Users.Application.Aggregates.User.Queries.GetProfile;

public sealed class GetUserProfileQuery : IQuery<GetUserProfileQueryResponse>
{
    public required int UserId { get; set; }
}

public sealed class GetUserProfileQueryResponse
{


}

public sealed class GetUserProfileQueryHandler(IEfReadonlyUnitOfWork uof) : IQueryHandler<GetUserProfileQuery, GetUserProfileQueryResponse>
{
    public Task<GetUserProfileQueryResponse> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

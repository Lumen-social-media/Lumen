using Lumen.Users.Application.Common;
using Lumen.Users.Domain.Common.UnitOfWorks;

namespace Lumen.Users.Application.Aggregates.User.Queries.GetProfile;

public sealed class GetProfileQuery : IQuery<GetProfileQueryResponse>
{
}

public sealed class GetProfileQueryResponse
{


}

public sealed class GetProfileQueryHandler(IEfReadonlyUnitOfWork uof) : IQueryHandler<GetProfileQuery, GetProfileQueryResponse>
{
    public Task<GetProfileQueryResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

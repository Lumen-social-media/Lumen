using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.Community.Repositories;

public interface ICommunityEfReadOnlyRepository : IEfReadOnlyRepository<CommunityEntity, int>
{
}

using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.Community.Repositories;

public interface ICommunityEfWriteOnlyRepository : IEfWriteOnlyRepository<CommunityEntity, int>
{
}

using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.Community.Repositories;

public interface ICommunityEfWriteOnlyRepository : IEfWriteOnlyRepository<CommunityEntity, int>
{
}

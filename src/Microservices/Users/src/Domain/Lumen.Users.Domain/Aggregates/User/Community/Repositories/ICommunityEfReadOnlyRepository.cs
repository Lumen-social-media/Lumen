using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.Community.Repositories;

public interface ICommunityEfReadOnlyRepository : IEfReadOnlyRepository<CommunityEntity, int>
{
}

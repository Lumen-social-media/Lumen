using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.Post.Repositories;

public interface IPosEfReadOnlyRepository : IEfReadOnlyRepository<PostEntity, int>
{
}

using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.RootComment.Repositories;

public interface IRootCommentEfReadOnlyRepository : IEfReadOnlyRepository<RootCommentEntity, int>
{
}

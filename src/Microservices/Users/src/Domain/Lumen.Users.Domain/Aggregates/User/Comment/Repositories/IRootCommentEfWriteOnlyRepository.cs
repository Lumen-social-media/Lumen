using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.Comment.Repositories;

public interface IRootCommentEfWriteOnlyRepository : IEfWriteOnlyRepository<RootCommentEntity, int>
{
}

using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.RootAnswerComment.Repositories;

public interface IRootAnswerCommentEfWriteOnlyRepository : IEfWriteOnlyRepository<RootAnswerCommentEntity, int>
{
}

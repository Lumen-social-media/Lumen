using Lumen.Users.Domain.Aggregates.User.RootComment;
using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.RootAnswerComment.Repositories;

public interface IRootAnswerCommentEfReadOnlyRepository : IEfReadOnlyRepository<RootCommentEntity, int>
{
}

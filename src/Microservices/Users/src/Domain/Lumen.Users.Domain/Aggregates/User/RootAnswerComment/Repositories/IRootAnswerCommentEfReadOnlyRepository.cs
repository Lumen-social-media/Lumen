using Lumen.Users.Domain.Aggregates.User.Comment;
using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.RootAnswerComment.Repositories;

public interface IRootAnswerCommentEfReadOnlyRepository : IEfReadOnlyRepository<RootCommentEntity, int>
{
}

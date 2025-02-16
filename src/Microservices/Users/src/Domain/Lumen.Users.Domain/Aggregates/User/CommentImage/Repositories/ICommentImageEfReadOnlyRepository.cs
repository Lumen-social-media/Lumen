using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.CommentImage.Repositories;

public interface ICommentImageEfReadOnlyRepository : IEfReadOnlyRepository<CommentImageEntity, int>
{
}

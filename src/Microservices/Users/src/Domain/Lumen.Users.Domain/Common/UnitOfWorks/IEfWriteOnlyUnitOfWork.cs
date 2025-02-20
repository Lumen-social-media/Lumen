using Lumen.Users.Domain.Aggregates.Community.Repositories;
using Lumen.Users.Domain.Aggregates.User.CommentImage.Repositories;
using Lumen.Users.Domain.Aggregates.User.Post.Repositories;
using Lumen.Users.Domain.Aggregates.User.PostImage.Repositories;
using Lumen.Users.Domain.Aggregates.User.Repositories;
using Lumen.Users.Domain.Aggregates.User.RootAnswerComment.Repositories;
using Lumen.Users.Domain.Aggregates.User.RootComment.Repositories;
using Lumen.Users.Domain.Aggregates.User.UserBoard.Repositories;

namespace Lumen.Users.Domain.Common.UnitOfWorks;

public interface IEfWriteOnlyUnitOfWork
{
    public IUserEfWriteOnlyRepository Users { get; }
    public IUserBoardEfWriteOnlyRepository UserBoards { get; }
    public ICommunityEfWriteOnlyRepository Communities { get; }
    public IPostEfWriteOnlyRepository Posts { get; }
    public IPostImageEfWriteOnlyRepository PostImages { get; }
    public ICommentImageEfWriteOnlyRepository CommentImages { get; }
    public IRootCommentEfWriteOnlyRepository RootComments { get; }
    public IRootAnswerCommentEfWriteOnlyRepository RootAnswerComments { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

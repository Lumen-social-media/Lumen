using Lumen.Users.Domain.Aggregates.Community.Repositories;
using Lumen.Users.Domain.Aggregates.User.CommentImage.Repositories;
using Lumen.Users.Domain.Aggregates.User.Post.Repositories;
using Lumen.Users.Domain.Aggregates.User.PostImage.Repositories;
using Lumen.Users.Domain.Aggregates.User.Repositories;
using Lumen.Users.Domain.Aggregates.User.RootAnswerComment.Repositories;
using Lumen.Users.Domain.Aggregates.User.RootComment.Repositories;
using Lumen.Users.Domain.Aggregates.User.UserBoard.Repositories;
using Lumen.Users.Domain.Common.UnitOfWorks;

namespace Lumen.Users.Infrastructure.Common;

public sealed class EfWriteOnlyUnitOfWork(IUserEfWriteOnlyRepository users,
                                          IUserBoardEfWriteOnlyRepository userBoards,
                                          ICommunityEfWriteOnlyRepository communities,
                                          IPostEfWriteOnlyRepository posts,
                                          IPostImageEfWriteOnlyRepository postImages,
                                          ICommentImageEfWriteOnlyRepository commentImages,
                                          IRootCommentEfWriteOnlyRepository rootComments,
                                          IRootAnswerCommentEfWriteOnlyRepository rootAnswerComments,
                                          LumenDbContext dbContext) : IEfWriteOnlyUnitOfWork
{
    public IUserEfWriteOnlyRepository Users => users;
    public IUserBoardEfWriteOnlyRepository UserBoards => userBoards;
    public ICommunityEfWriteOnlyRepository Communities => communities;
    public IPostEfWriteOnlyRepository Posts => posts;
    public IPostImageEfWriteOnlyRepository PostImages => postImages;
    public ICommentImageEfWriteOnlyRepository CommentImages => commentImages;
    public IRootCommentEfWriteOnlyRepository RootComments => rootComments;
    public IRootAnswerCommentEfWriteOnlyRepository RootAnswerComments => rootAnswerComments;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}

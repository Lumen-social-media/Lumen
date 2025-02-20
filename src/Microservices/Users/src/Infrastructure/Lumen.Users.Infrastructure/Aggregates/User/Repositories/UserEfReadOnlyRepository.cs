using Lumen.Users.Domain.Aggregates.User;
using Lumen.Users.Domain.Aggregates.User.Post;
using Lumen.Users.Domain.Aggregates.User.Repositories;
using Lumen.Users.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Lumen.Users.Infrastructure.Aggregates.User.Repositories;

public sealed class UserEfReadOnlyRepository(LumenDbContext dbContext) : EfReadOnlyRepositoryBase<UserEntity, int>(dbContext), IUserEfReadOnlyRepository
{
    public Task<UserEntity> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PostEntity>> GetUserPosts(int id, CancellationToken cancellationToken = default)
    {
        var userBoardId = await DbContext.UserBoards // find user's board
            .AsNoTracking()
            .Where(u => u.OwnerId == id)
            .Select(u => new { u.Id })
            .FirstOrDefaultAsync(cancellationToken);

        var userPosts = await DbContext.Posts // find only user's posts where communityId is NULL
            .AsNoTracking()
            .Where(p => p.BoardId == userBoardId!.Id && p.CommunityId == default)
            .ToListAsync(cancellationToken);

        return userPosts;
    }
}

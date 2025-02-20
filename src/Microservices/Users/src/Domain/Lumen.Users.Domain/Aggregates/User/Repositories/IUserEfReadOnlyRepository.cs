using Lumen.Users.Domain.Aggregates.User.Post;
using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.Repositories;

public interface IUserEfReadOnlyRepository : IEfReadOnlyRepository<UserEntity, int>
{
    public Task<UserEntity> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
    public Task<IEnumerable<PostEntity>> GetUserPosts(int id, CancellationToken cancellationToken = default);
}

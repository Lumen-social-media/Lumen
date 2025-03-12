using Lumen.Identity.Domain.Users;

namespace Lumen.Identity.Application.Users.Repositories;

public interface IUserCachedRepository
{
    public Task<User> AddAsync(User user, CancellationToken cancellationToken = default);
    public Task<User?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public void Remove(User user, CancellationToken cancellationToken = default);

}

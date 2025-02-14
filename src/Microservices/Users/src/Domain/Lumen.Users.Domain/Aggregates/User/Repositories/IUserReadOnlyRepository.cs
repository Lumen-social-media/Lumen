using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.Repositories;

public interface IUserReadOnlyRepository : IReadOnlyRepository<User, int>
{
    public Task<User> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
}

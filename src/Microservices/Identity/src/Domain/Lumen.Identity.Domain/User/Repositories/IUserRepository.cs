using Lumen.Identity.Domain.Common;

namespace Lumen.Identity.Domain.User.Repositories;

public interface IUserRepository : IRepository<UserEntity, int>
{
    public Task CreateAsync(UserEntity user, string password);
}

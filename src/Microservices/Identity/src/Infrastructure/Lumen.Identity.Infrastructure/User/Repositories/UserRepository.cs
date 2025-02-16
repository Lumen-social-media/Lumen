using Lumen.Identity.Domain.User;
using Lumen.Identity.Domain.User.Repositories;
using Lumen.Identity.Infrastructure.Common;

namespace Lumen.Identity.Infrastructure.User.Repositories;

public sealed class UserRepository : RepositoryBase<UserEntity, int>, IUserRepository
{
    public Task CreateAsync(UserEntity user, string password)
    {
        throw new NotImplementedException();
    }
}

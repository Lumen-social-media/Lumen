using Lumen.Users.Domain.Aggregates.User;
using Lumen.Users.Domain.Aggregates.User.Repositories;
using Lumen.Users.Infrastructure.Common;

namespace Lumen.Users.Infrastructure.Aggregates.User.Repositories;

public sealed class UserEfWriteOnlyRepository(LumenDbContext dbContext) : EfWriteOnlyRepositoryBase<UserEntity, int>(dbContext), IUserEfWriteOnlyRepository
{
}

using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Domain.Aggregates.User.Repositories;

public interface IUserWriteOnlyRepository : IWriteOnlyRepository<User, int>
{
}

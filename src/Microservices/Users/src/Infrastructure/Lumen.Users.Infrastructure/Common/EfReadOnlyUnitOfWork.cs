using Lumen.Users.Domain.Aggregates.User.Repositories;
using Lumen.Users.Domain.Common.UnitOfWorks;

namespace Lumen.Users.Infrastructure.Common;

public sealed class EfReadOnlyUnitOfWork(IUserEfReadOnlyRepository users) : IEfReadonlyUnitOfWork
{
    public IUserEfReadOnlyRepository Users { get; } = users;
}

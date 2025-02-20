using Lumen.Users.Domain.Aggregates.User.Repositories;

namespace Lumen.Users.Domain.Common.UnitOfWorks;

public interface IEfReadonlyUnitOfWork
{
    public IUserEfReadOnlyRepository Users { get; }
}

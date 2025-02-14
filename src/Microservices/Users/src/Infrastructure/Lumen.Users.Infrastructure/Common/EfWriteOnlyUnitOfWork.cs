using Lumen.Users.Domain.Common.UnitOfWorks;

namespace Lumen.Users.Infrastructure.Common;

public sealed class EfWriteOnlyUnitOfWork() : IEfWriteOnlyUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

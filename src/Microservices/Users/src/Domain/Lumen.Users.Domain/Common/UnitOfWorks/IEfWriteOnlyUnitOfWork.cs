namespace Lumen.Users.Domain.Common.UnitOfWorks;

public interface IEfWriteOnlyUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

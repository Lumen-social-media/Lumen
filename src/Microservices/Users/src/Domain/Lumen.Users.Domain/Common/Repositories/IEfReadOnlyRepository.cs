namespace Lumen.Users.Domain.Common.Repositories;

public interface IEfReadOnlyRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : notnull
{
    public Task<TEntity?> FindByIdAsync(TId id, CancellationToken cancellationToken = default);
}

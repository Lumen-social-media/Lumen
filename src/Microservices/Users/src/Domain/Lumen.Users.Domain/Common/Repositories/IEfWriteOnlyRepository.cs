namespace Lumen.Users.Domain.Common.Repositories;

public interface IEfWriteOnlyRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : notnull
{
    public Task<TEntity?> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    public TEntity? Update(TEntity entity, CancellationToken cancellationToken = default);
    public Task<TEntity?> DeleteByIdAsync(TId id, CancellationToken cancellationToken = default);
}

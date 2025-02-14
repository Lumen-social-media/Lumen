namespace Lumen.Users.Domain.Common.Repositories;

public interface IReadOnlyRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : notnull
{
    public Task<TEntity?> FindByIdAsync(TId id, CancellationToken cancellationToken = default);
}

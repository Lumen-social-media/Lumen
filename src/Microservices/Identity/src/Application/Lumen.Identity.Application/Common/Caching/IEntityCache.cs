using Lumen.Identity.Domain.Common;

namespace Lumen.Identity.Application.Common.Caching;

public interface IEntityCache<TEntity, TId>
    where TEntity : IEntity<TId>
    where TId : notnull
{
    public Task SetByIdAsync(TEntity entity, CancellationToken cancellationToken = default);
    public Task<TEntity?> GetByIdAsync(string key, CancellationToken cancellationToken = default);
    public Task RemoveAsync(string key, CancellationToken cancellationToken = default);
}

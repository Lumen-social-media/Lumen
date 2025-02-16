using Lumen.Users.Domain.Common;
using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Infrastructure.Common;

public abstract class EfReadOnlyRepositoryBase<TEntity, TId>(LumenDbContext dbContext) : IEfReadOnlyRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : notnull
{
    public async Task<TEntity?> FindByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        var entity = await dbContext.Set<TEntity>().FindAsync([id], cancellationToken);

        return entity;
    }
}

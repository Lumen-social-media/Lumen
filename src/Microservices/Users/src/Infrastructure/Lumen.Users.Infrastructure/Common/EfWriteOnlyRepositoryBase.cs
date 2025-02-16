using Lumen.Users.Domain.Common;
using Lumen.Users.Domain.Common.Repositories;

namespace Lumen.Users.Infrastructure.Common;

public abstract class EfWriteOnlyRepositoryBase<TEntity, TId>(LumenDbContext dbContext) : IEfWriteOnlyRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : notnull
{
    public async Task<TEntity?> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        return result.Entity;
    }

    public async Task<TEntity?> DeleteByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        var entity = await dbContext.Set<TEntity>().FindAsync([id], cancellationToken);

        if (entity is null)
            return null;

        dbContext.Set<TEntity>().Remove(entity);

        return entity;
    }

    public virtual TEntity? Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        dbContext.Set<TEntity>().Update(entity);

        return entity;
    }
}

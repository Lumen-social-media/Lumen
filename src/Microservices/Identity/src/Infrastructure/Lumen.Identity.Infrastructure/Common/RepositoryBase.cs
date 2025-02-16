using Lumen.Identity.Domain.Common;

namespace Lumen.Identity.Infrastructure.Common;

public abstract class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : notnull
{

}

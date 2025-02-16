namespace Lumen.Identity.Domain.Common;

public interface IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : notnull
{
}

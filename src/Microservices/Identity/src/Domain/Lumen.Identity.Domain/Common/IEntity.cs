namespace Lumen.Identity.Domain.Common;

public interface IEntity<TId> where TId : notnull
{
    public TId Id { get; set; }
}

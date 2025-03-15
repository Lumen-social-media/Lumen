namespace Lumen.Profile.Domain.Common;

public interface IEntity<TId> where TId : notnull
{
    public TId Id { get; set; }
}

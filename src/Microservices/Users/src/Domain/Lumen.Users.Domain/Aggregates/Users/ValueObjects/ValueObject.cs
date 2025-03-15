namespace Lumen.Profile.Domain.Aggregates.Users.ValueObjects;

public abstract record ValueObject
{
    public abstract void Validate();
}

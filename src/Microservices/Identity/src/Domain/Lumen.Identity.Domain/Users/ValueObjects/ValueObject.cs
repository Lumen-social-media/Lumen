namespace Lumen.Identity.Domain.Users.ValueObjects;

public abstract record ValueObject
{
    public abstract void Validate();
}

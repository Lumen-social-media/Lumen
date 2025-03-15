using FluentValidation;

namespace Lumen.Profile.Domain.Aggregates.Users.ValueObjects.Name;

public sealed record Name : ValueObject
{
    public string Value { get; private set; }

    public Name(string value)
    {
        Value = value;
    }

    public static Name Create(string value)
    {
        var name = new Name(value);

        var validator = new NameValidator();
        validator.ValidateAndThrow(name);

        return name;
    }

    public override void Validate()
    {
        var validator = new NameValidator();
        validator.ValidateAndThrow(this);
    }
}

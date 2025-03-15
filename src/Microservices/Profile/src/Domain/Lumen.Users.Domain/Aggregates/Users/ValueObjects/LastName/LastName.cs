using FluentValidation;

namespace Lumen.Profile.Domain.Aggregates.Users.ValueObjects.LastName;

public sealed record LastName : ValueObject
{
    public string Value { get; private set; }

    public LastName(string value)
    {
        Value = value;
    }

    public static LastName Create(string value)
    {
        var lastName = new LastName(value);
        var validator = new LastNameValidator();
        validator.ValidateAndThrow(lastName);

        return lastName;
    }

    public override void Validate()
    {
        var validator = new LastNameValidator();
        validator.ValidateAndThrow(this);
    }
}

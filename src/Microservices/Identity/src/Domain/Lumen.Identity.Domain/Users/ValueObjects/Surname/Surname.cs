using FluentValidation;

namespace Lumen.Identity.Domain.Users.ValueObjects.Surname;

public sealed record Surname : ValueObject
{
    public string Value { get; private set; }

    public Surname(string value)
    {
        Value = value;
    }

    public static Surname Create(string value)
    {
        var surname = new Surname(value);

        var validator = new SurnameValidator();
        validator.ValidateAndThrow(surname);

        return surname;
    }

    public override void Validate()
    {
        var validator = new SurnameValidator();
        validator.ValidateAndThrow(this);
    }
}

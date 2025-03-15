using FluentValidation;

namespace Lumen.Profile.Domain.Aggregates.Users.ValueObjects.Email;

public sealed record Email : ValueObject
{
    public string Value { get; private set; }

    public Email()
    {

    }

    public static Email Create(string value)
    {
        var email = new Email { Value = value };

        var validator = new EmailValidator();
        validator.ValidateAndThrow(email);

        return email;
    }

    public Email Update(string value)
    {
        Value = value;

        var validator = new EmailValidator();
        validator.ValidateAndThrow(this);

        return this;
    }

    public override void Validate()
    {
        var validator = new EmailValidator();
        validator.ValidateAndThrow(this);
    }
}

using FluentValidation;

namespace Lumen.Identity.Domain.Users.ValueObjects.UserName;

public sealed record UserName : ValueObject
{
    public string Value { get; private set; }

    public UserName(string value)
    {
        Value = value;
    }

    public static UserName Create(string value)
    {
        var userName = new UserName(value);

        var validator = new UserNameValidator();
        validator.ValidateAndThrow(userName);

        return userName;
    }

    public override void Validate()
    {
        var validator = new UserNameValidator();
        validator.ValidateAndThrow(this);
    }
}

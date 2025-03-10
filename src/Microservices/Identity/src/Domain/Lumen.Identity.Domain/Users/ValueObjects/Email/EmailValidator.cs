using FluentValidation;

namespace Lumen.Identity.Domain.Users.ValueObjects.Email;

public sealed class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(b => b.Value)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .Matches(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")
            .WithMessage("Value should be email.");
    }
}

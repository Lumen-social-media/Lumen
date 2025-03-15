using FluentValidation;

namespace Lumen.Profile.Domain.Aggregates.Users;

public sealed class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        
    }
}

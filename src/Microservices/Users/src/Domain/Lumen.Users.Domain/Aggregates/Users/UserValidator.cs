using FluentValidation;

namespace Lumen.Users.Domain.Aggregates.Users;

public sealed class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        
    }
}

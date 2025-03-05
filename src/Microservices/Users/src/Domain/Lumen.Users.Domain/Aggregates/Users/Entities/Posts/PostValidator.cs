using FluentValidation;

namespace Lumen.Users.Domain.Aggregates.Users.Entities.Posts;

public sealed class PostValidator : AbstractValidator<Post>
{
    public PostValidator()
    {
        RuleFor(x => x.Body)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(50000)
            .WithMessage("Post must be between 1 and 50000 characters");

        RuleFor(x => x.Owner)
            .NotNull()
            .WithMessage("Post must have an author");

        RuleFor(x => x.CreatedAt)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Creation date cannot be in the future");
    }
}

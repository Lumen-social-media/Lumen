using FluentValidation;

namespace Lumen.Profile.Domain.Aggregates.Users.Entities.RootComments;

public sealed class RootCommentValidator : AbstractValidator<RootComment>
{
    public RootCommentValidator()
    {
        RuleFor(x => x.Body)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(10000)
            .WithMessage("Comment must be between 1 and 10000 characters");

        RuleFor(x => x.Owner)
            .NotNull()
            .WithMessage("Comment must have an author");

        RuleFor(x => x.Post)
            .NotNull()
            .WithMessage("Comment must be linked to a post");

        RuleFor(x => x.CreatedAt)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Creation date cannot be in the future");
    }
} 
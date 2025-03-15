using FluentValidation;

namespace Lumen.Profile.Domain.Aggregates.Users.Entities.RootAnswerComments;

public sealed class RootAnswerCommentValidator : AbstractValidator<RootAnswerComment>
{
    public RootAnswerCommentValidator()
    {
        RuleFor(x => x.Body)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(10000)
            .WithMessage("Reply must be between 1 and 10000 characters");

        RuleFor(x => x.Owner)
            .NotNull()
            .WithMessage("Reply must have an author");

        RuleFor(x => x.Root)
            .NotNull()
            .WithMessage("Reply must be linked to a comment");

        RuleFor(x => x.CreatedAt)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Creation date cannot be in the future");
    }
} 
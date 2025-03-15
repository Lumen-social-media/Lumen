using FluentValidation;

namespace Lumen.Profile.Domain.Aggregates.Users.Entities.CommentImages;

public sealed class CommentImageValidator : AbstractValidator<CommentImage>
{
    public CommentImageValidator()
    {
        RuleFor(x => x.Url)
            .NotEmpty()
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("Image URL must be valid");

        RuleFor(x => x.Owner)
            .NotNull()
            .WithMessage("Image must have an owner");

        RuleFor(x => x.Comment)
            .NotNull()
            .WithMessage("Image must be linked to a comment");

        RuleFor(x => x.PublishedAt)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Publication date cannot be in the future");
    }
} 
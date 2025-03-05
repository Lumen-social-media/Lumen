using FluentValidation;

namespace Lumen.Users.Domain.Aggregates.Users.Entities.PostImages;

public sealed class PostImageValidator : AbstractValidator<PostImage>
{
    public PostImageValidator()
    {
        RuleFor(x => x.Url)
            .NotEmpty()
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("Image URL must be valid");

        RuleFor(x => x.Owner)
            .NotNull()
            .WithMessage("Image must have an owner");

        RuleFor(x => x.Post)
            .NotNull()
            .WithMessage("Image must be linked to a post");

        RuleFor(x => x.PublishedAt)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Publication date cannot be in the future");
    }
} 
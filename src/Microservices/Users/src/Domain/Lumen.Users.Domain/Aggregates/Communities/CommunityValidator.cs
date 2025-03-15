using FluentValidation;

namespace Lumen.Profile.Domain.Aggregates.Communities;

public sealed class CommunityValidator : AbstractValidator<Community>
{

    public CommunityValidator()
    {
        RuleFor(b => b.Description)
            .NotNull()
            .MaximumLength(int.MaxValue);
    }
}

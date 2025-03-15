using FluentValidation;
using Lumen.Profile.Domain.Aggregates.Users.Entities.RootComments;
using Lumen.Profile.Domain.Common;

namespace Lumen.Profile.Domain.Aggregates.Users.Entities.RootAnswerComments;

public sealed class RootAnswerComment : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required User Owner { get; set; } = default!;
    public Guid OwnerId { get; set; }

    public required RootComment Root { get; set; } = default!;
    public Guid RootId { get; set; }

    public required string Body { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    internal RootAnswerComment()
    {

    }

    public static RootAnswerComment Create(string body, User owner, RootComment root)
    {
        var answer = new RootAnswerComment
        {
            Body = body,
            Owner = owner,
            OwnerId = owner.Id,
            Root = root,
            RootId = root.Id
        };

        var validator = new RootAnswerCommentValidator();
        validator.ValidateAndThrow(answer);

        return answer;
    }
}

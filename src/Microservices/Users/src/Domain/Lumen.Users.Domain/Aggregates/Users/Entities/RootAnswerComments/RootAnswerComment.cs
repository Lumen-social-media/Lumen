using FluentValidation;
using Lumen.Users.Domain.Aggregates.Users.Entities.RootComments;
using Lumen.Users.Domain.Aggregates.Users.ValueObjects;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.Users.Entities.RootAnswerComments;

public sealed class RootAnswerComment : IEntity<int>
{
    public int Id { get; set; }

    public required User Owner { get; set; } = default!;
    public UserId OwnerId { get; set; }

    public required RootComment Root { get; set; } = default!;
    public int RootId { get; set; }

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

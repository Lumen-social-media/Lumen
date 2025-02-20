using Lumen.Users.Domain.Aggregates.User.RootComment;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.RootAnswerComment;

public sealed class RootAnswerCommentEntity : IEntity<int>
{
    public int Id { get; set; }

    public required UserEntity Owner { get; set; } = default!;
    public int OwnerId { get; set; }

    public required RootCommentEntity Root { get; set; } = default!;
    public int RootId { get; set; }

    public required string Body { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}

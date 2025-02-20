using Lumen.Users.Domain.Aggregates.User.Post;
using Lumen.Users.Domain.Aggregates.User.RootAnswerComment;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.RootComment;

public sealed class RootCommentEntity : IEntity<int>
{
    public int Id { get; set; }

    public UserEntity Owner { get; set; } = default!;
    public int OwnerId { get; set; }

    public PostEntity Post { get; set; } = default!;
    public int PostId { get; set; }

    public required string Body { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public IEnumerable<RootAnswerCommentEntity> Answers { get; set; } = new List<RootAnswerCommentEntity>();
}

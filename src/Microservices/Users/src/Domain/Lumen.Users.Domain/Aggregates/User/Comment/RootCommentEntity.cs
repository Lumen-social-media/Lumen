using Lumen.Users.Domain.Aggregates.User.Post;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.Comment;

public sealed class RootCommentEntity : IEntity<int>
{
    public int Id { get; set; }

    public UserEntity Owner { get; set; } = default!;
    public int OwnerId { get; set; }

    public PostEntity Post { get; set; } = default!;
    public int PostId { get; set; }

    public required string Body { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

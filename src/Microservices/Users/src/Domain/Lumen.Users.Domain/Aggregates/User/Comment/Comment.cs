using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.Comment;

public sealed class Comment : IEntity<int>
{
    public int Id { get; set; }

    public User Owner { get; set; } = default!;
    public int OwnerId { get; set; }

    public Post.Post Post { get; set; } = default!;
    public int PostId { get; set; }

    public Comment? Parent { get; set; }
    public int ParentId { get; set; }

    public int Position { get; set; }

    public required string Body { get; set; }
    public string[] ImagesUrls { get; set; } = default!;
}

using Lumen.Users.Domain.Aggregates.User.RootComment;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.CommentImage;

public sealed class CommentImageEntity : IEntity<int>
{
    public int Id { get; set; }

    public RootCommentEntity Comment { get; set; } = default!;
    public int CommentId { get; set; }

    public required string Url { get; set; }

    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
}

using Lumen.Users.Domain.Aggregates.User.Post;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.PostImage;

public sealed class PostImageEntity : IEntity<int>
{
    public int Id { get; set; }

    public PostEntity Post { get; set; } = default!;
    public int PostId { get; set; }

    public required string Url { get; set; }

    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
}

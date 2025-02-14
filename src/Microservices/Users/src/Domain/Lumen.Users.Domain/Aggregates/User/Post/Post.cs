using Lumen.Users.Domain.Aggregates.User.Community;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.Post;

public sealed class Post : IEntity<int>
{
    public int Id { get; set; }

    public string[] ImagesUrls { get; set; } = default!;

    public Community.Community? Community { get; set; }
    public int CommunityId { get; set; }

    /// <summary>
    /// It is a repost of post
    /// </summary>
    public Post? Parent { get; set; }
    public int ParentId { get; set; }

    public UserBoard.UserBoard Board { get; set; } = default!;
    public int BoardId { get; set; }
}

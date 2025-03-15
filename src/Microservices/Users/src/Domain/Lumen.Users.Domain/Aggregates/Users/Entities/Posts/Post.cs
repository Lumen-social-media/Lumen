using Lumen.Profile.Domain.Aggregates.Communities;
using Lumen.Profile.Domain.Aggregates.Users.Entities.PostImages;
using Lumen.Profile.Domain.Aggregates.Users.Entities.RootComments;
using Lumen.Profile.Domain.Common;

namespace Lumen.Profile.Domain.Aggregates.Users.Entities.Posts;

public sealed class Post : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Body { get; set; }

    public Community? Community { get; set; }
    public Guid? CommunityId { get; set; }

    public User Owner { get; set; } = default!;
    public Guid OwnerId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public IEnumerable<PostImage> Images { get; set; } = new List<PostImage>();
    public IEnumerable<RootComment> RootComments { get; set; } = new List<RootComment>();

    private Post()
    {

    }

    internal static Post Create(string body, User owner, Community? community)
    {
        var post = new Post
        {
            Body = body,
            Owner = owner,
            OwnerId = owner.Id,
            Community = community,
            CommunityId = community?.Id
        };

        return post;
    }
}

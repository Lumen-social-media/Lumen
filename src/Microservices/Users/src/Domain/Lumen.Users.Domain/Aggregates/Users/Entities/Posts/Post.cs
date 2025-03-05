using Lumen.Users.Domain.Aggregates.Communities;
using Lumen.Users.Domain.Aggregates.Users.Entities.PostImages;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts.Dtos;
using Lumen.Users.Domain.Aggregates.Users.Entities.RootComments;
using Lumen.Users.Domain.Aggregates.Users.ValueObjects;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.Users.Entities.Posts;

public sealed class Post : IEntity<int>
{
    public int Id { get; set; }
    public required string Body { get; set; }

    public Community? Community { get; set; }
    public int CommunityId { get; set; }

    public User Owner { get; set; } = default!;
    public UserId OwnerId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public IEnumerable<PostImage> Images { get; set; } = new List<PostImage>();
    public IEnumerable<RootComment> RootComments { get; set; } = new List<RootComment>();

    private Post()
    {

    }

    internal static Post Create(CreatePostDto dto)
    {
        var post = new Post
        {
            Body = dto.Body,
            Owner = dto.Owner,
            OwnerId = dto.Owner.Id,
            Community = dto.Community,
            CommunityId = dto.Community is null ? 0 : dto.Community.Id
        };

        return post;
    }


}

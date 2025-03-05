using Lumen.Users.Domain.Aggregates.Communities;

namespace Lumen.Users.Domain.Aggregates.Users.Entities.Posts.Dtos;

public sealed record CreatePostDto
{
    public required string Body { get; set; }
    public required User Owner { get; set; }
    public int OwnerId { get; set; }
    public Community? Community { get; set; }
    public int CommunityId { get; set; }
}

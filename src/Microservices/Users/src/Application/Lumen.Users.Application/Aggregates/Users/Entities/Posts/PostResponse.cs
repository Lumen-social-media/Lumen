namespace Lumen.Profile.Application.Aggregates.Users.Entities.Posts;

public sealed record PostResponse
{
    public Guid Id { get; set; }
    public required string Body { get; set; }
    public Guid? CommunityId { get; set; }
    public Guid OwnerId { get; set; }
    public DateTime CreatedAt { get; set; }
}

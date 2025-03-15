namespace Lumen.Profile.Application.Aggregates.Users.Entities.PostImages;

public sealed record PostImageResponse
{
    public Guid Id { get; set; }
    public required string Url { get; set; }
    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
    public Guid PostId { get; set; }
    public Guid OwnerId { get; set; }
} 
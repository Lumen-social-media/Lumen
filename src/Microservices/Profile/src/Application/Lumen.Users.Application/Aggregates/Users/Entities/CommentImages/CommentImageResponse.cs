namespace Lumen.Profile.Application.Aggregates.Users.Entities.CommentImages;

public sealed record CommentImageResponse
{
    public Guid Id { get; set; }
    public required string Url { get; set; }
    public DateTime PublishedAt { get; set; }
    public Guid CommentId { get; set; }
    public Guid OwnerId { get; set; }
} 
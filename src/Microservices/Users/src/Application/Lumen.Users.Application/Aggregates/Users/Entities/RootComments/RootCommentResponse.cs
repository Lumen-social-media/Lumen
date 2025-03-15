namespace Lumen.Profile.Application.Aggregates.Users.Entities.RootComments;

public sealed record RootCommentResponse
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public Guid PostId { get; set; }
    public required string Body { get; set; }
    public DateTime CreatedAt { get; set; }
} 
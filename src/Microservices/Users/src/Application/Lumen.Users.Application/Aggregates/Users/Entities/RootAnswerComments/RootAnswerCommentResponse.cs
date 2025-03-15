namespace Lumen.Profile.Application.Aggregates.Users.Entities.RootAnswerComments;

public sealed record RootAnswerCommentResponse
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public Guid RootId { get; set; }
    public required string Body { get; set; }
    public DateTime CreatedAt { get; set; }
} 
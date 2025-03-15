namespace Lumen.Profile.Application.Aggregates.Communities;

public sealed record CommunityResponse
{
    public Guid Id { get; set; }
    public string AvatarUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid OwnerId { get; set; }
} 
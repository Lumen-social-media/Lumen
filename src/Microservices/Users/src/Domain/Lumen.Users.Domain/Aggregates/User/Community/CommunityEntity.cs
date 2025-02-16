using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.Community;

public sealed class CommunityEntity : IEntity<int>
{
    public int Id { get; set; }

    public UserEntity Owner { get; set; } = default!;
    public int OwnerId { get; set; }

    public string[] ImagesUrls { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
}


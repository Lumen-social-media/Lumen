using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.Community;

public sealed class Community : IEntity<int>
{
    public int Id { get; set; }

    public User Owner { get; set; } = default!;
    public int OwnerId { get; set; }

    public string[] ImagesUrls { get; set; } = default!;
}

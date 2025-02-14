using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.UserBoard;

public sealed class UserBoard : IEntity<int>
{
    public int Id { get; set; }

    public required User Owner { get; set; }
    public int OwnerId { get; set; }

    public bool IsPublic { get; set; }
}

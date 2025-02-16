using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.UserBoard;

public sealed class UserBoardEntity : IEntity<int>
{
    public int Id { get; set; }

    public required UserEntity Owner { get; set; }
    public int OwnerId { get; set; }

    public bool IsPublic { get; set; }
}

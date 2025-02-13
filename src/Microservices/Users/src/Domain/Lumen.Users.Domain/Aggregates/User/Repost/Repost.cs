using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.Repost;

public sealed class Repost : IEntity<int>
{
    public int Id { get; set; }
}

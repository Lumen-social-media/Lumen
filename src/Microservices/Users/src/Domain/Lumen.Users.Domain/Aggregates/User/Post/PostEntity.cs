using Lumen.Users.Domain.Aggregates.User.Community;
using Lumen.Users.Domain.Aggregates.User.PostImage;
using Lumen.Users.Domain.Aggregates.User.UserBoard;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.User.Post;

public sealed class PostEntity : IEntity<int>
{
    public int Id { get; set; }

    public IEnumerable<PostImageEntity> Images { get; set; } = new List<PostImageEntity>();

    public CommunityEntity? Community { get; set; }
    public int CommunityId { get; set; }

    public UserBoardEntity Board { get; set; } = default!;
    public int BoardId { get; set; }
}

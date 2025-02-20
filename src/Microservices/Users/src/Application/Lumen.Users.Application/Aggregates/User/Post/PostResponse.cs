using Lumen.Users.Application.Aggregates.Community;
using Lumen.Users.Application.Aggregates.User.PostImage;
using Lumen.Users.Application.Aggregates.User.UserBoard;

namespace Lumen.Users.Application.Aggregates.User.Post;

public sealed class PostResponse
{
    public int Id { get; set; }

    public IEnumerable<PostImageResponse> Images { get; set; } = new List<PostImageResponse>();

    public CommunityResponse? Community { get; set; }
    public int CommunityId { get; set; }

    public UserBoardResponse Board { get; set; } = default!;
    public int BoardId { get; set; }
}

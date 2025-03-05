using Lumen.Users.Domain.Aggregates.Users.Entities.RootComments;

namespace Lumen.Users.Domain.Aggregates.Users.Entities.CommentImages.Dtos;

public sealed record CreateCommentImageDto
{
    public required string Url { get; set; }
    public required User Owner { get; set; }
    public required RootComment Comment { get; set; }
}

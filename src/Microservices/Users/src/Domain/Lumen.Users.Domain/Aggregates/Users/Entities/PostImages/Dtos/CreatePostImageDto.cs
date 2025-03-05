using Lumen.Users.Domain.Aggregates.Users.Entities.Posts;

namespace Lumen.Users.Domain.Aggregates.Users.Entities.PostImages.Dtos;

public sealed record CreatePostImageDto
{
    public required string Url { get; set; }
    public required User Owner { get; set; }
    public required Post Post { get; set; }
}

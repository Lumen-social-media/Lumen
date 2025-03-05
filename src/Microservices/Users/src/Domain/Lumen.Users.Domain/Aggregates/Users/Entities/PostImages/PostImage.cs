using FluentValidation;
using Lumen.Users.Domain.Aggregates.Users.Entities.PostImages.Dtos;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Users.Domain.Aggregates.Users.ValueObjects;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.Users.Entities.PostImages;

public sealed class PostImage : IEntity<int>
{
    public int Id { get; set; }

    public Post Post { get; set; } = default!;
    public int PostId { get; set; }

    public User Owner { get; set; } = default!;
    public UserId OwnerId { get; set; }

    public required string Url { get; set; }

    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

    internal PostImage()
    {

    }

    public static PostImage Create(CreatePostImageDto dto)
    {
        var image = new PostImage
        {
            Url = dto.Url,
            Owner = dto.Owner,
            OwnerId = dto.Owner.Id,
            Post = dto.Post,
            PostId = dto.Post.Id
        };

        var validator = new PostImageValidator();
        validator.ValidateAndThrow(image);

        return image;
    }
}

using FluentValidation;
using Lumen.Profile.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Profile.Domain.Common;

namespace Lumen.Profile.Domain.Aggregates.Users.Entities.PostImages;

public sealed class PostImage : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Post Post { get; set; } = default!;
    public Guid PostId { get; set; }

    public User Owner { get; set; } = default!;
    public Guid OwnerId { get; set; }

    public required string Url { get; set; }

    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

    internal PostImage()
    {

    }

    public static PostImage Create(string url, User owner, Post post)
    {
        var image = new PostImage
        {
            Url = url,
            Owner = owner,
            OwnerId = owner.Id,
            Post = post,
            PostId = post.Id
        };

        var validator = new PostImageValidator();
        validator.ValidateAndThrow(image);

        return image;
    }
}

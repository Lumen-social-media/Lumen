using FluentValidation;
using Lumen.Profile.Domain.Aggregates.Users.Entities.RootComments;
using Lumen.Profile.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Lumen.Profile.Domain.Aggregates.Users.Entities.CommentImages;

public sealed class CommentImage : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public RootComment Comment { get; set; } = default!;
    public Guid CommentId { get; set; }

    public User Owner { get; set; } = default!;
    public Guid OwnerId { get; set; }

    public required string Url { get; set; }

    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

    [SetsRequiredMembers]
    internal CommentImage()
    {

    }

    internal static CommentImage Create(string url, User owner, RootComment comment)
    {
        var image = new CommentImage
        {
            Url = url,
            Owner = owner,
            OwnerId = owner.Id,
            Comment = comment,
            CommentId = comment.Id
        };

        var validator = new CommentImageValidator();
        validator.ValidateAndThrow(image);

        return image;
    }
}

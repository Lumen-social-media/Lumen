using FluentValidation;
using Lumen.Users.Domain.Aggregates.Users.Entities.CommentImages.Dtos;
using Lumen.Users.Domain.Aggregates.Users.Entities.RootComments;
using Lumen.Users.Domain.Aggregates.Users.ValueObjects;
using Lumen.Users.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace Lumen.Users.Domain.Aggregates.Users.Entities.CommentImages;

public sealed class CommentImage : IEntity<int>
{
    public int Id { get; set; }

    public RootComment Comment { get; set; } = default!;
    public int CommentId { get; set; }

    public User Owner { get; set; } = default!;
    public UserId OwnerId { get; set; }

    public required string Url { get; set; }

    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

    [SetsRequiredMembers]
    internal CommentImage()
    {

    }

    internal static CommentImage Create(CreateCommentImageDto dto)
    {
        var image = new CommentImage
        {
            Url = dto.Url,
            Owner = dto.Owner,
            OwnerId = dto.Owner.Id,
            Comment = dto.Comment,
            CommentId = dto.Comment.Id
        };

        var validator = new CommentImageValidator();
        validator.ValidateAndThrow(image);

        return image;
    }

}

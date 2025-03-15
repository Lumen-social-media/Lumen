using Lumen.Profile.Domain.Aggregates.Users.Entities.CommentImages;

namespace Lumen.Profile.Application.Aggregates.Users.Entities.CommentImages.Mappers.Extensions;

public static class CommentImageMapperExtensions
{
    public static CommentImageResponse ToResponse(this CommentImage image)
    {
        var response = new CommentImageResponse
        {
            Id = image.Id,
            Url = image.Url,
            PublishedAt = image.PublishedAt,
            CommentId = image.CommentId,
            OwnerId = image.OwnerId
        };

        return response;
    }
} 
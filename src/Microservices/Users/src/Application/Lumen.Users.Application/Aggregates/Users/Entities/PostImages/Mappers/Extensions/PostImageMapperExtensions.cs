using Lumen.Profile.Domain.Aggregates.Users.Entities.PostImages;

namespace Lumen.Profile.Application.Aggregates.Users.Entities.PostImages.Mappers.Extensions;

public static class PostImageMapperExtensions
{
    public static PostImageResponse ToResponse(this PostImage image)
    {
        var response = new PostImageResponse
        {
            Id = image.Id,
            Url = image.Url,
            PublishedAt = image.PublishedAt,
            PostId = image.PostId,
            OwnerId = image.OwnerId
        };

        return response;
    }
} 
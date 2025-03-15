using Lumen.Profile.Domain.Aggregates.Users.Entities.Posts;

namespace Lumen.Profile.Application.Aggregates.Users.Entities.Posts.Mappers.Extensions;

public static class PostMapperExtensions
{
    public static PostResponse ToResponse(this Post post)
    {
        var response = new PostResponse
        {
            Id = post.Id,
            Body = post.Body,
            CommunityId = post.CommunityId,
            OwnerId = post.OwnerId,
            CreatedAt = post.CreatedAt
        };

        return response;
    }
} 
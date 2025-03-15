using Lumen.Profile.Domain.Aggregates.Users.Entities.RootComments;

namespace Lumen.Profile.Application.Aggregates.Users.Entities.RootComments.Mappers.Extensions;

public static class RootCommentMapperExtensions
{
    public static RootCommentResponse ToResponse(this RootComment comment)
    {
        var response = new RootCommentResponse
        {
            Id = comment.Id,
            Body = comment.Body,
            CreatedAt = comment.CreatedAt,
            OwnerId = comment.OwnerId,
            PostId = comment.PostId
        };

        return response;
    }
} 
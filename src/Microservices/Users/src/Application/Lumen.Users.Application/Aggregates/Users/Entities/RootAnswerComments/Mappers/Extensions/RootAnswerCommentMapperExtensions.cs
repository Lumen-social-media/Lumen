using Lumen.Profile.Domain.Aggregates.Users.Entities.RootAnswerComments;

namespace Lumen.Profile.Application.Aggregates.Users.Entities.RootAnswerComments.Mappers.Extensions;

public static class RootAnswerCommentMapperExtensions
{
    public static RootAnswerCommentResponse ToResponse(this RootAnswerComment comment)
    {
        var response = new RootAnswerCommentResponse
        {
            Id = comment.Id,
            Body = comment.Body,
            CreatedAt = comment.CreatedAt,
            OwnerId = comment.OwnerId,
            RootId = comment.RootId
        };

        return response;
    }
} 
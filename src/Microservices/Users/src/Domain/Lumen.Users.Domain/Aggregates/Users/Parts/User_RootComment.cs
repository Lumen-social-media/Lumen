using FluentValidation;
using Lumen.Profile.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Profile.Domain.Aggregates.Users.Entities.RootComments;

namespace Lumen.Profile.Domain.Aggregates.Users;

public sealed partial class User
{
    public IEnumerable<RootComment> RootComments => rootComments;
    private List<RootComment> rootComments = new List<RootComment>();

    public RootComment AddRootComment(string body, Post post)
    {
        var comment = RootComment.Create(body, this, post);

        var validator = new RootCommentValidator();
        validator.ValidateAndThrow(comment);

        rootComments.Add(comment);

        return comment;
    }

    public void RemoveRootComment(RootComment comment)
    {
        rootComments.Remove(comment);
    }

    public static RootComment PartiallyUpdateRootComment(RootComment comment, string? body)
    {
        if (!string.IsNullOrWhiteSpace(body))
            comment.Body = body;

        return comment;
    }
}

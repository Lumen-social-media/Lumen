using FluentValidation;
using Lumen.Users.Domain.Aggregates.Users.Entities.RootComments;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts;

namespace Lumen.Users.Domain.Aggregates.Users;

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

    public RootComment PartiallyUpdateRootComment(RootComment comment, string? body)
    {
        if (!string.IsNullOrWhiteSpace(body))
            comment.Body = body;

        return comment;
    }
}

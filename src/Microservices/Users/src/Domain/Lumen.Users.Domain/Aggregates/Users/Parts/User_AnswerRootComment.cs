using FluentValidation;
using Lumen.Users.Domain.Aggregates.Users.Entities.RootAnswerComments;
using Lumen.Users.Domain.Aggregates.Users.Entities.RootComments;

namespace Lumen.Users.Domain.Aggregates.Users;

public sealed partial class User
{
    public IEnumerable<RootAnswerComment> RootAnswerComments => rootAnswerComments;
    private List<RootAnswerComment> rootAnswerComments = new List<RootAnswerComment>();

    public void AddAnswerRootComment(string body, RootComment root)
    {
        var answer = RootAnswerComment.Create(body, this, root);

        var validator = new RootAnswerCommentValidator();
        validator.ValidateAndThrow(answer);

        rootAnswerComments.Add(answer);
    }

    public void RemoveAnswerRootComment(RootAnswerComment comment)
    {
        rootAnswerComments.Remove(comment);
    }
}

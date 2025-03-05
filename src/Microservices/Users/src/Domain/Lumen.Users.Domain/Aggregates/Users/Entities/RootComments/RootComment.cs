using FluentValidation;
using Lumen.Users.Domain.Aggregates.Users.Entities.CommentImages;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Users.Domain.Aggregates.Users.Entities.RootAnswerComments;
using Lumen.Users.Domain.Aggregates.Users.ValueObjects;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.Users.Entities.RootComments;

public sealed class RootComment : IEntity<int>
{
    public int Id { get; set; }

    public IEnumerable<CommentImage> Images { get; set; } = new List<CommentImage>();
    
    public User Owner { get; set; } = default!;
    public UserId OwnerId { get; set; }

    public Post Post { get; set; } = default!;
    public int PostId { get; set; }

    public required string Body { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public IEnumerable<RootAnswerComment> Answers { get; set; } = new List<RootAnswerComment>();

    internal RootComment()
    {

    }

    public static RootComment Create(string body, User owner, Post post)
    {
        var comment = new RootComment
        {
            Body = body,
            Owner = owner,
            OwnerId = owner.Id,
            Post = post,
            PostId = post.Id
        };

        var validator = new RootCommentValidator();
        validator.ValidateAndThrow(comment);

        return comment;
    }
}

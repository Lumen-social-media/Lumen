using FluentValidation;
using Lumen.Profile.Domain.Aggregates.Users.Entities.CommentImages;
using Lumen.Profile.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Profile.Domain.Aggregates.Users.Entities.RootAnswerComments;
using Lumen.Profile.Domain.Common;

namespace Lumen.Profile.Domain.Aggregates.Users.Entities.RootComments;

public sealed class RootComment : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public IEnumerable<CommentImage> Images { get; set; } = new List<CommentImage>();
    
    public User Owner { get; set; } = default!;
    public Guid OwnerId { get; set; }

    public Post Post { get; set; } = default!;
    public Guid PostId { get; set; }

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

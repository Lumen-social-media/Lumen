using FluentValidation;
using Lumen.Users.Domain.Aggregates.Users;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts;

namespace Lumen.Users.Domain.Aggregates.Communities;

public sealed partial class Community
{
    #region Posts
    public IEnumerable<Post> Posts => posts;
    private List<Post> posts = new List<Post>();

    public Post WritePost(string body, User owner)
    {
        var post = Post.Create(body, owner, this);
        posts.Add(post);

        var validator = new PostValidator();
        validator.ValidateAndThrow(post);

        return post;
    }

    public Post RemovePost(Post post)
    {
        posts.Remove(post);

        return post;
    }

    public void PartiallyUpdatePost(string? description)
    {
        if (!string.IsNullOrWhiteSpace(description))
        {
            Description = description;
        }

        var validator = new CommunityValidator();
        validator.ValidateAndThrow(this);
    }
    #endregion
}
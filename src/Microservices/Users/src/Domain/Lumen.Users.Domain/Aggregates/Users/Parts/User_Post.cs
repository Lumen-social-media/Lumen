using Lumen.Profile.Domain.Aggregates.Communities;
using Lumen.Profile.Domain.Aggregates.Users.Entities.Posts;

namespace Lumen.Profile.Domain.Aggregates.Users;

public sealed partial class User
{
    public IEnumerable<Post> Posts => posts;
    private List<Post> posts = new List<Post>();

    public Post AddPost(string body, Community? community)
    {
        var post = Post.Create(body, this, community);
        posts.Add(post);

        return post;
    }

    public Post RemovePost(Post post)
    {
        posts.Remove(post);

        return post;
    }

    public static Post PartiallyUpdatePost(Post post, string? body)
    {
        if (!string.IsNullOrWhiteSpace(body))
            post.Body = body;

        return post;
    }
}

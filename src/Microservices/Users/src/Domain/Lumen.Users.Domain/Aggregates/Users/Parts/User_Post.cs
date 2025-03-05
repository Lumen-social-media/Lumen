using Lumen.Users.Domain.Aggregates.Users.Entities.Posts;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts.Dtos;

namespace Lumen.Users.Domain.Aggregates.Users;

public sealed partial class User
{
    public IEnumerable<Post> Posts => posts;
    private List<Post> posts = new List<Post>();

    public Post AddPost(CreatePostDto dto)
    {
        var post = Post.Create(dto);
        posts.Add(post);

        return post;
    }

    public Post RemovePost(Post post)
    {
        posts.Remove(post);

        return post;
    }

    public Post PartiallyUpdatePost()
    {
        throw new NotImplementedException();
    }
}

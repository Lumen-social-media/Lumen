using FluentValidation;
using Lumen.Users.Domain.Aggregates.Users.Entities.PostImages;
using Lumen.Users.Domain.Aggregates.Users.Entities.Posts;

namespace Lumen.Users.Domain.Aggregates.Users;

public sealed partial class User
{
    public IEnumerable<PostImage> PostImages => postImages;
    private  List<PostImage> postImages = new List<PostImage>();

    public void AddPostImage(string url, Post post)
    {
        var image = PostImage.Create(url, this, post);

        var validator = new PostImageValidator();
        validator.ValidateAndThrow(image);

        postImages.Add(image);
    }

    public void RemovePostImage(PostImage postImage)
    {
        postImages.Remove(postImage);
    }
}

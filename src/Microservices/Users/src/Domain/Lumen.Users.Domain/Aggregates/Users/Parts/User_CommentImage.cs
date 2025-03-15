using FluentValidation;
using Lumen.Profile.Domain.Aggregates.Users.Entities.CommentImages;
using Lumen.Profile.Domain.Aggregates.Users.Entities.RootComments;

namespace Lumen.Profile.Domain.Aggregates.Users;

public sealed partial class User
{
    public IEnumerable<CommentImage> CommentImages => commentImages;
    private List<CommentImage> commentImages = new List<CommentImage>();

    public void AddCommentImage(string url, RootComment comment)
    {
        var image = CommentImage.Create(url, this, comment);

        var validator = new CommentImageValidator();
        validator.ValidateAndThrow(image);

        commentImages.Add(image);
    }

    public void RemoveCommentImage(CommentImage commentImage)
    {
        commentImages.Remove(commentImage);
    }
}

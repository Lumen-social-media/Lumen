using FluentValidation;
using Lumen.Users.Domain.Aggregates.Users;
using Lumen.Users.Domain.Aggregates.Users.ValueObjects;
using Lumen.Users.Domain.Common;

namespace Lumen.Users.Domain.Aggregates.Communities;

public sealed partial class Community : IAggregateRoot, IEntity<int>
{
    public int Id { get; set; }

    public string AvatarUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User Owner { get; set; } = default!;
    public UserId OwnerId { get; set; }


    public Community()
    {


    }

    #region Community
    public static Community Create(UserId ownerId, string avatarUrl = "", string description = "")
    {
        var community = new Community
        {
            OwnerId = ownerId,
            AvatarUrl = avatarUrl,
            Description = description
        };

        var validator = new CommunityValidator();
        validator.ValidateAndThrow(community);

        return community;
    }

    public void PartiallyUpdate(string? description)
    {
        if (!string.IsNullOrWhiteSpace(description))
        {
            Description = description;
        }

        var validator = new CommunityValidator();
        validator.ValidateAndThrow(this);
    }

    public void ChangeAvatar(string avatarUrl)
    {
        AvatarUrl = avatarUrl;

        var validator = new CommunityValidator();
        validator.ValidateAndThrow(this);
    }
    #endregion
}


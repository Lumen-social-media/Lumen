using Lumen.Identity.Domain.Users;

namespace Lumen.Identity.Infrastructure.Users.Consumers.Messages;

public sealed class UserUpdatedMessage
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string Description { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public string Hometown { get; set; } = string.Empty;
    public DateOnly? BirthDate { get; set; }
    public Language Language { get; set; } = Language.NotSet;
    public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.NotSet;
    public string CurrentCity { get; set; } = string.Empty;
    public string PersonalSite { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.NotSet;
    public string SchoolName { get; set; } = string.Empty;
    public bool HasPublicProfile { get; set; } = true;
}

using Lumen.Identity.Domain.Users;

namespace Lumen.Identity.Application.Users.Messages;

public sealed class UserRegisteredMessage
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public DateOnly? BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime LastLoginAt { get; set; }
    public string Hometown { get; set; } = string.Empty;
    public Language Language { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public string CurrentCity { get; set; } = string.Empty;
    public string PersonalSite { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public string SchoolName { get; set; } = string.Empty;
    public bool HasPublicProfile { get; set; }

}

using Lumen.Identity.Domain.User;
using Microsoft.AspNetCore.Identity;

namespace Lumen.Identity.Infrastructure.User;

public sealed class InfrastructureUser : IdentityUser<int>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public DateOnly? BirthDate { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public DateTime LastLoginAt { get; set; } = DateTime.UtcNow;

    public string Hometown { get; set; } = string.Empty;
    public Language Language { get; set; } = Language.NotSet;
    public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.NotSet;
    public string CurrentCity { get; set; } = string.Empty;
    public string PersonalSite { get; set; } = string.Empty;

    public Gender Gender { get; set; } = Gender.NotSet;

    public string SchoolName { get; set; } = string.Empty;

    public IEnumerable<UserEntity> CanViewPrivateProfile { get; set; } = new List<UserEntity>();

    public bool HasPublicProfile { get; set; }
}

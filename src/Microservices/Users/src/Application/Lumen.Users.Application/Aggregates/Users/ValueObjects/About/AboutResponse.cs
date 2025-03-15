using Lumen.Profile.Domain.Aggregates.Users;

namespace Lumen.Profile.Application.Aggregates.Users.ValueObjects.About;

public sealed record AboutResponse
{
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
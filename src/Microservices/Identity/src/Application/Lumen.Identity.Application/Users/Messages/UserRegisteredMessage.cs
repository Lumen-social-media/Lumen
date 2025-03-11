using System.Diagnostics.CodeAnalysis;
using Lumen.Identity.Domain.Users;

namespace Lumen.Identity.Application.Users.Messages;

[method: SetsRequiredMembers]
public sealed class UserRegisteredMessage(Guid id, string userName, string name, string surname, string email, string lastName, string about, string avatarUrl, DateOnly? birthDate, DateTime registrationDate, DateTime lastLoginAt, string hometown, Language language, MaritalStatus maritalStatus, string currentCity, string personalSite, Gender gender, string schoolName, bool hasPublicProfile)
{
    public Guid Id { get; set; } = id;
    public required string UserName { get; set; } = userName;
    public required string Name { get; set; } = name;
    public required string Surname { get; set; } = surname;
    public required string Email { get; set; } = email;
    public string LastName { get; set; } = lastName;
    public string About { get; set; } = about;
    public string AvatarUrl { get; set; } = avatarUrl;
    public DateOnly? BirthDate { get; set; } = birthDate;
    public DateTime RegistrationDate { get; set; } = registrationDate;
    public DateTime LastLoginAt { get; set; } = lastLoginAt;
    public string Hometown { get; set; } = hometown;
    public Language Language { get; set; } = language;
    public MaritalStatus MaritalStatus { get; set; } = maritalStatus;
    public string CurrentCity { get; set; } = currentCity;
    public string PersonalSite { get; set; } = personalSite;
    public Gender Gender { get; set; } = gender;
    public string SchoolName { get; set; } = schoolName;
    public bool HasPublicProfile { get; set; } = hasPublicProfile;
}

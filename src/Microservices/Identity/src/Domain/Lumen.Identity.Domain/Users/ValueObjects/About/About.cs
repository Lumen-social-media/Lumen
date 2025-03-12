using FluentValidation;

namespace Lumen.Identity.Domain.Users.ValueObjects.About;

public sealed record About : ValueObject
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

    public About(string description,
             string avatarUrl,
             string hometown,
             DateOnly? birthDate,
             Language language,
             MaritalStatus maritalStatus,
             string currentCity,
             string personalSite,
             Gender gender,
             string schoolName,
             bool hasPublicProfile)
    {
        Description = description;
        AvatarUrl = avatarUrl;
        Hometown = hometown;
        BirthDate = birthDate;
        Language = language;
        MaritalStatus = maritalStatus;
        CurrentCity = currentCity;
        PersonalSite = personalSite;
        Gender = gender;
        SchoolName = schoolName;
        HasPublicProfile = hasPublicProfile;
    }

    public static About Create(string description,
                               string avatarUrl,
                               string hometown,
                               DateOnly? birthDate,
                               Language language,
                               MaritalStatus maritalStatus,
                               string currentCity,
                               string personalSite,
                               Gender gender,
                               string schoolName,
                               bool hasPublicProfile)
    {
        var about = new About(description,
                              avatarUrl,
                              hometown,
                              birthDate,
                              language,
                              maritalStatus,
                              currentCity,
                              personalSite,
                              gender,
                              schoolName,
                              hasPublicProfile);

        var validator = new AboutValidator();
        validator.ValidateAndThrow(about);

        return about;
    }

    public override void Validate()
    {
        var validator = new AboutValidator();
        validator.ValidateAndThrow(this);
    }
}

namespace Lumen.Users.Domain.Aggregates.Users.Dtos;

public sealed record CreateUserDto
{
    public required string UserName { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public DateOnly? BirthDate { get; set; }
    public string Hometown { get; set; } = string.Empty;
    public Language Language { get; set; } = Language.NotSet;
    public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.NotSet;
    public string CurrentCity { get; set; } = string.Empty;
    public string PersonalSite { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.NotSet;
    public string SchoolName { get; set; } = string.Empty;
    public bool HasPublicProfile { get; set; }
    public bool OnlyRegisteredUsersCanViewProfile { get; set; }

}

namespace Lumen.Users.Domain.Aggregates.Users.Dtos;

public sealed record PartiallyUpdateUserDto
{
    public string? UserName { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? LastName { get; set; }
    public string? About { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? Hometown { get; set; }
    public Language? Language { get; set; }
    public MaritalStatus? MaritalStatus { get; set; }
    public string? CurrentCity { get; set; }
    public string? PersonalSite { get; set; }
    public Gender? Gender { get; set; }
    public string? SchoolName { get; set; }
    public bool? HasPublicProfile { get; set; }
    public bool? OnlyRegisteredUsersCanViewProfile { get; set; }
}

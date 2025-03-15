using Lumen.Profile.Domain.Aggregates.Users;

namespace Lumen.Profile.Application.Aggregates.Users.Mappers.Extensions;

public static class UserMapperExtensions
{
    public static UserResponse ToResponse(this User user)
    {
        var response = new UserResponse
        {
            Id = user.Id,
            UserName = user.UserName.Value,
            Name = user.Name.Value,
            Surname = user.Surname.Value,
            LastName = user.LastName.Value,
            Email = user.Email.Value,
            AvatarUrl = user.About.AvatarUrl,
            BirthDate = user.About.BirthDate,
            Description = user.About.Description,
            RegistrationDate = user.RegistrationDate,
            LastLoginAt = user.LastLoginAt,
            Hometown = user.About.Hometown,
            Language = user.About.Language,
            MaritalStatus = user.About.MaritalStatus,
            CurrentCity = user.About.CurrentCity,
            PersonalSite = user.About.PersonalSite,
            Gender = user.About.Gender,
            SchoolName = user.About.SchoolName,
            HasPublicProfile = user.About.HasPublicProfile
        };

        return response;
    }
}

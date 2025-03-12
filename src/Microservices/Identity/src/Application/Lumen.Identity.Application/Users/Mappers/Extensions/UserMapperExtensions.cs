using Lumen.Identity.Application.Users.Commands;
using Lumen.Identity.Application.Users.Messages;
using Lumen.Identity.Domain.Users;
using Lumen.Identity.Domain.Users.ValueObjects.About;
using Lumen.Identity.Domain.Users.ValueObjects.Email;
using Lumen.Identity.Domain.Users.ValueObjects.LastName;
using Lumen.Identity.Domain.Users.ValueObjects.Name;
using Lumen.Identity.Domain.Users.ValueObjects.Surname;
using Lumen.Identity.Domain.Users.ValueObjects.UserName;

namespace Lumen.Identity.Application.Users.Mappers.Extensions;

public static class UserMapperExtensions
{
    public static User ToUser(this RegisterUserWithJwtCommand command, string passwordHash)
    {
        var userName = UserName.Create(command.UserName);
        var name = Name.Create(command.Name);
        var surname = Surname.Create(command.Surname);
        var lastName = LastName.Create(command.LastName);
        var email = Email.Create(command.Email);
        var about = About.Create(command.Description,
                                 command.AvatarUrl,
                                 command.Hometown,
                                 command.BirthDate,
                                 command.Language,
                                 command.MaritalStatus,
                                 command.CurrentCity,
                                 command.PersonalSite,
                                 command.Gender,
                                 command.SchoolName,
                                 command.HasPublicProfile);

        var user = User.Create(userName, name, surname, lastName, email, about, passwordHash);

        return user;
    }

    public static UserRegisteredMessage ToUserRegisteredMessage(this User user)
    {
        var message = new UserRegisteredMessage
        {
            Id = user.Id,
            UserName = user.UserName.Value,
            Name = user.Name.Value,
            Surname = user.Surname.Value,
            Email = user.Email.Value,
            LastName = user.LastName.Value,
            Description = user.About.Description,
            AvatarUrl = user.About.AvatarUrl,
            BirthDate = user.About.BirthDate,
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

        return message;
    }
}

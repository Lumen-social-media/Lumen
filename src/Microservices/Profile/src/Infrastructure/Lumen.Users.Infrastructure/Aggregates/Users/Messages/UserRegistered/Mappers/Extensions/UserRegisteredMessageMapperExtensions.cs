using Lumen.Profile.Domain.Aggregates.Users;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.About;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.Email;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.LastName;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.Name;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.Surname;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.UserName;

namespace Lumen.Profile.Infrastructure.Aggregates.Users.Messages.UserRegistered.Mappers.Extensions;

public static class UserRegisteredMessageMapperExtensions
{
    public static User ToUser(this UserRegisteredMessage message)
    {
        var userName = UserName.Create(message.UserName);
        var name = Name.Create(message.Name);
        var surname = Surname.Create(message.Surname);
        var lastName = LastName.Create(message.LastName);
        var email = Email.Create(message.Email);
        var about = About.Create(message.Description,
                                 message.AvatarUrl,
                                 message.Hometown,
                                 message.BirthDate,
                                 message.Language,
                                 message.MaritalStatus,
                                 message.CurrentCity,
                                 message.PersonalSite,
                                 message.Gender,
                                 message.SchoolName,
                                 message.HasPublicProfile);

        var user = User.Create(userName, name, surname, lastName, email, about);

        return user;
    }
}

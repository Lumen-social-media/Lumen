using Lumen.Identity.Domain.Users;
using Lumen.Identity.Domain.Users.ValueObjects.About;
using Lumen.Identity.Domain.Users.ValueObjects.Email;
using Lumen.Identity.Domain.Users.ValueObjects.LastName;
using Lumen.Identity.Domain.Users.ValueObjects.Name;
using Lumen.Identity.Domain.Users.ValueObjects.Surname;
using Lumen.Identity.Domain.Users.ValueObjects.UserName;

namespace Lumen.Identity.Infrastructure.Users.Consumers.Messages.Mappers.Extensions;

public static class UserUpdatedMessageMapperExtensions
{
    public static User ToUser(this UserUpdatedMessage message)
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

        var user = User.Create(userName, name, surname, lastName, email, about, string.Empty);

        return user;
    }
}

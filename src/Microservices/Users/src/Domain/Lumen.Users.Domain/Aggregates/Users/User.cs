using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.About;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.Email;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.LastName;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.Name;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.Surname;
using Lumen.Profile.Domain.Aggregates.Users.ValueObjects.UserName;
using Lumen.Profile.Domain.Common;

namespace Lumen.Profile.Domain.Aggregates.Users;

public sealed partial class User : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public UserName UserName { get; set; }
    public Name Name { get; set; }
    public Surname Surname { get; set; }
    public LastName LastName { get; set; }
    public Email Email { get; set; }
    public About About { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public DateTime LastLoginAt { get; set; } = DateTime.UtcNow;

    private User(UserName userName, Name name, Surname surname, LastName lastName, Email email, About about)
    {
        UserName = userName;
        Name = name;
        Surname = surname;
        LastName = lastName;
        Email = email;
        About = about;
    }

    private User()
    {

    }

    public static User Create(UserName userName, Name name, Surname surname, LastName lastName, Email email, About about)
    {
        var user = new User(userName, name, surname, lastName, email, about);

        user.UserName.Validate();
        user.Email.Validate();
        user.Name.Validate();
        user.Surname.Validate();
        user.LastName.Validate();
        user.About.Validate();

        return user;
    }

    public User UpdateEmail(string value)
    {
        var newEmail = Email.Create(value);
        Email = newEmail;

        return this;
    }

    public User UpdateUserName(string value)
    {
        var newUserName = UserName.Create(value);
        UserName = newUserName;

        return this;
    }

    public User UpdateName(string value)
    {
        var newName = Name.Create(value);
        Name = newName;

        return this;
    }

    public User UpdateSurname(string value)
    {
        var newSurname = Surname.Create(value);
        Surname = newSurname;

        return this;
    }

    public User UpdateLastName(string value)
    {
        var newLastName = LastName.Create(value);
        LastName = newLastName;

        return this;
    }
}

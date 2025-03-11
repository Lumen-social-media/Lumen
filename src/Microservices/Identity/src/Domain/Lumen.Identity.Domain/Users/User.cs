using Lumen.Identity.Domain.Common;
using Lumen.Identity.Domain.Users.ValueObjects.About;
using Lumen.Identity.Domain.Users.ValueObjects.Email;
using Lumen.Identity.Domain.Users.ValueObjects.LastName;
using Lumen.Identity.Domain.Users.ValueObjects.Name;
using Lumen.Identity.Domain.Users.ValueObjects.Surname;
using Lumen.Identity.Domain.Users.ValueObjects.UserName;

namespace Lumen.Identity.Domain.Users;

public sealed class User : IEntity<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public UserName UserName { get; set; }
    public Name Name { get; set; }
    public Surname Surname { get; set; }
    public LastName LastName { get; set; }
    public Email Email { get; set; }
    public About About { get; set; }

    public string PasswordHash { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    public DateTime LastLoginAt { get; set; } = DateTime.UtcNow;

    private User(UserName userName, Name name, Surname surname, LastName lastName, Email email, About about, string passwordHash)
    {
        UserName = userName;
        Name = name;
        Surname = surname;
        LastName = lastName;
        Email = email;
        About = about;
        PasswordHash = passwordHash;
    }

    private User()
    {

    }

    public static User Create(UserName userName, Name name, Surname surname, LastName lastName, Email email, About about, string passwordHash)
    {
        var user = new User(userName, name, surname, lastName, email, about, passwordHash);

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

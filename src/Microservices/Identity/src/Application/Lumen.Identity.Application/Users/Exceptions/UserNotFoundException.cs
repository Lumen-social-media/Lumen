namespace Lumen.Identity.Application.Users.Exceptions;

public sealed class UserNotFoundException : Exception
{
    public UserNotFoundException(string email) : base($"User with email '{email}' not found.")
    {

    }

}

namespace Lumen.Users.Application.Aggregates.User.Exceptions;

public sealed class UserNotFoundException : Exception
{
    public UserNotFoundException(int id) : base($"User with id '{id}' not found.")
    {

    }

    public UserNotFoundException(string userName) : base($"User with userName '{userName}' not found.")
    {

    }
}

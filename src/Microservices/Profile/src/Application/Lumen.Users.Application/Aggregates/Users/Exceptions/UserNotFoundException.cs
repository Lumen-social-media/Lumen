namespace Lumen.Profile.Application.Aggregates.Users.Exceptions;

public sealed class UserNotFoundException : Exception
{
    public UserNotFoundException(Guid id) : base($"User with id {id} not found.")
    {

    }

    public UserNotFoundException(string email) : base($"User with email {email} not found.")
    {

    }
}

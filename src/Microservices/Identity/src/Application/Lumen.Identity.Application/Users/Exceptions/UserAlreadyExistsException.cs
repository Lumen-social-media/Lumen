namespace Lumen.Identity.Application.Users.Exceptions;

public sealed class UserAlreadyExistsException(string email) : Exception($"User with email '{email}' already exists.")
{
}

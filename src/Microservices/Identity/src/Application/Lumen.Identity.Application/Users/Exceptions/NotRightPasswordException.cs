namespace Lumen.Identity.Application.Users.Exceptions;

public sealed class NotRightPasswordException(string password) : UnauthorizedAccessException($"password '{password}' not right.")
{
}

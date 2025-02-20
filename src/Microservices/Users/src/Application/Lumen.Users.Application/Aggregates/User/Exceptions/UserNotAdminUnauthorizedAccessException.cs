namespace Lumen.Users.Application.Aggregates.User.Exceptions;

public sealed class UserNotAdminUnauthorizedAccessException(string? message) : UnauthorizedAccessException(message)
{

}

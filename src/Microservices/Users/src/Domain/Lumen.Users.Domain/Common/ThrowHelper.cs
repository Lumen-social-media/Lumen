namespace Lumen.Users.Domain.Common;

public static class ThrowHelper
{
    /// <summary>
    /// Throws <see cref="UnauthorizedAccessException"/> if <paramref name="principal"/> not authenticated
    /// </summary>
    /// <param name="principal"></param>
    /// <param name="message"></param>
    /// <exception cref="UnauthorizedAccessException"></exception>
    //public static void ThrowIfNotAuthenticated(ClaimsPrincipal principal, string? message = null)
    //{
    //    if (!principal.IsAuthenticated())
    //        throw new UnauthorizedAccessException(message);
    //}

    public static void ThrowUnauthorizedException(string? message = null)
    {
        throw new UnauthorizedAccessException(message);
    }
}

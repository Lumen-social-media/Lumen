using System.Security.Claims;

namespace Lumen.Users.Application.Common.Extensions;

public static class UserClaimsPrincipalExtensions
{
    public static bool IsAdmin(this ClaimsPrincipal principal)
    {
        var roleClaim = principal.FindFirst(ClaimTypes.Role);

        if (roleClaim is null)
        {
            return false;
        }

        if (roleClaim.Value != "Admin")
        {
            return false;
        }

        return true;
    }

    public static int FindUserId(this ClaimsPrincipal principal)
    {
        var claim = principal.FindFirst(ClaimTypes.NameIdentifier)!;
        var id = int.Parse(claim.Value);

        return id;
    }
}

using Lumen.Users.Application.Common.Auth;
using System.Security.Claims;

namespace Lumen.Users.Application.Common.Extensions;

public static class UserClaimsPrincipalExtensions
{
    public static bool IsAdmin(this ClaimsPrincipal principal)
    {
        if (!principal.IsAuthenticated()) return false;

        var roleClaim = principal.FindFirst(ClaimTypes.Role);

        if (roleClaim is null) return false;
        if (roleClaim.Value != RoleConstants.Admin) return false;

        return true;
    }

    public static bool IsAuthenticated(this ClaimsPrincipal principal)
    {
        if (principal.Identity is null) return false;

        return true;
    }

    public static int ExtractNameIdentifier(this ClaimsPrincipal principal)
    {
        var claim = principal.FindFirst(ClaimTypes.NameIdentifier)!;
        var id = int.Parse(claim.Value);

        return id;
    }
}

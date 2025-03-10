using System.Security.Claims;

namespace Lumen.Identity.Application.Common.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int ExtractUserId(this ClaimsPrincipal principal)
    {
        var userId = principal.FindFirst(ClaimTypes.NameIdentifier);

        if (userId is null) return default;

        return int.Parse(userId.Value);
    }
}

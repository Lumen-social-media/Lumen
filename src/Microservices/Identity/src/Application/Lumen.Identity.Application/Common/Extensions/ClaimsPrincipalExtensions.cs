using System.Security.Claims;

namespace Lumen.Identity.Application.Common.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid ExtractUserId(this ClaimsPrincipal principal)
    {
        var userId = principal.FindFirst(ClaimTypes.NameIdentifier);

        if (userId is null) return default;

        return Guid.Parse(userId.Value);
    }
}

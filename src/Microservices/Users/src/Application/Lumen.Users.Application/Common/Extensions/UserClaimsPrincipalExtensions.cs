using System.Security.Claims;

namespace Lumen.Users.Application.Common.Extensions;

public static class UserClaimsPrincipalExtensions
{
    public static bool IsAdmin(this ClaimsPrincipal principal)
    {
        principal.FindFirst("Admin");
        
        return true;
    }
}

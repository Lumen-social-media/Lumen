using System.Numerics;
using System.Security.Claims;

namespace Lumen.Profile.Application.Common.Extensions;

public static class UserClaimsPrincipalExtensions
{
    public static bool HasRole(this ClaimsPrincipal principal, string role)
    {
        var claim = principal.FindFirst(ClaimTypes.Role);

        if (claim is null) return false;
        if (claim.Value == role) return true;

        return false;
    }

    public static bool IsAdmin(this ClaimsPrincipal principal)
    {
        if (principal.HasRole("Admin"))
            return true;

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="principal"></param>
    /// <returns><see cref="Nullable"/> if </returns>
    public static Guid? ExtractId(this ClaimsPrincipal principal)
    {
        var claim = principal.FindFirst(ClaimTypes.NameIdentifier);

        if (claim is null) return null;

        var id = Guid.Parse(claim.Value);

        return id;
    }

    /// <summary>
    /// Checks principal id.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    /// <param name="principal"></param>
    /// <param name="id"></param>
    /// <returns>If principal id not equal <paramref name="id"/>, returns false, else return true</returns>
    public static bool HasId<TId>(this ClaimsPrincipal principal, TId? id)
        where TId : INumber<TId>
    {
        var principalId = principal.ExtractId();

        if (principalId.Equals(id))
            return false;

        return true;
    }

    public static bool IsAuthenticated(this ClaimsPrincipal principal)
    {
        if (principal.Identity is null || !principal.Identity.IsAuthenticated)
            return false;

        return true;
    }
}

using Lumen.Identity.Domain.Users;
using System.Security.Claims;

namespace Lumen.Identity.Application.Common.Auth;

public sealed class ClaimsFactory
{
    public List<Claim> Create(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, RoleContants.User)
        };

        return claims;
    }
}

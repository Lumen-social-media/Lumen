using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lumen.Identity.Application.Common.Auth.Jwt;

public sealed class JwtFactory(IOptions<JwtOptions> jwtOptions)
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public string Create(List<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));

        var jwtToken = new JwtSecurityToken(claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpiresInMinutes),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience
            );

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}

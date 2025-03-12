using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Lumen.Identity.Application.Common.Auth.Jwt;

public sealed class TokenValidationParametersFactory(IOptions<JwtOptions> options)
{
    public TokenValidationParameters Create()
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)),
            ValidateIssuer = true,
            ValidIssuer = options.Value.Issuer,
            ValidateAudience = true,
            ValidAudience = options.Value.Audience,
            RequireExpirationTime = true
        };
    }

    /// <summary>
    /// It needs for token validation in <see cref="Users.Commands.RefreshUserTokenCommand"/> to extract user id from token and don't validate expiration time
    /// </summary>
    /// <returns></returns>
    public TokenValidationParameters CreateWithoutLifeTimeValidation()
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)),
            ValidateIssuer = true,
            ValidIssuer = options.Value.Issuer,
            ValidateAudience = true,
            ValidAudience = options.Value.Audience,
            ValidateLifetime = false,
            RequireExpirationTime = false
        };
    }
}


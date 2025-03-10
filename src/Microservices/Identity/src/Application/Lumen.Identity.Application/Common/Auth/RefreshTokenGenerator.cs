using System.Security.Cryptography;

namespace Lumen.Identity.Application.Common.Auth;

public sealed class RefreshTokenGenerator
{
    public string Create()
    {
        var refreshToken = RandomNumberGenerator.GetHexString(50);

        return refreshToken;
    }
}

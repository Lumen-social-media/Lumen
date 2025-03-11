using System.Security.Cryptography;
using System.Text;

namespace Lumen.Identity.Application.Common.Auth;

public sealed class PasswordHasher
{
    public string Hash(string password)
    {
        var pass = SHA512.HashData(new MemoryStream(Encoding.UTF8.GetBytes(password), true));

        return Encoding.UTF8.GetString(pass);
    }
}

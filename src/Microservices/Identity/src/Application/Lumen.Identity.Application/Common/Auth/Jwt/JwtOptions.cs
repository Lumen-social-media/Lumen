namespace Lumen.Identity.Application.Common.Auth.Jwt;

public sealed class JwtOptions
{
    public required string SecretKey { get; set; }
    public required string Audience { get; set; }
    public required string Issuer { get; set; }
    public required int ExpiresInMinutes { get; set; }
}

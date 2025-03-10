namespace Lumen.Identity.Application.Users.Commands;

public sealed record AccessTokenResponse
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}

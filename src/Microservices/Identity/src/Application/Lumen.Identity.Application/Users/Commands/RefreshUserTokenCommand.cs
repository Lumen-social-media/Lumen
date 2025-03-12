using Lumen.Identity.Application.Common;
using Lumen.Identity.Application.Common.Auth;
using Lumen.Identity.Application.Common.Auth.Jwt;
using Lumen.Identity.Application.Common.Caching;
using Lumen.Identity.Application.Common.Extensions;
using Lumen.Identity.Application.Users.Exceptions;
using Lumen.Identity.UseCase.Common;
using Lumen.Identity.UseCase.Users.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Lumen.Identity.Application.Users.Commands;

public sealed record RefreshUserTokenCommand : ICommand<AccessTokenResponse>
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}

public sealed class RefreshUserTokenCommandHandler(IApplicationDbContext context,
                                                   ICache cache,
                                                   JwtFactory jwtFactory,
                                                   ClaimsFactory claimsFactory,
                                                   RefreshTokenGenerator refreshGenerator,
                                                   TokenValidationParametersFactory paramsFactory) : ICommandHandler<RefreshUserTokenCommand, AccessTokenResponse>
{
    public async Task<AccessTokenResponse> Handle(RefreshUserTokenCommand command, CancellationToken cancellationToken)
    {
        var principal = new JwtSecurityTokenHandler().ValidateToken(command.AccessToken, paramsFactory.CreateWithoutLifeTimeValidation(), out SecurityToken validatedToken);
        var userIdFromAccessToken = principal.ExtractUserId();

        var cachedRefreshToken = await cache.GetStringAsync($"user:{userIdFromAccessToken}:refresh-token", cancellationToken)
            ?? throw new UnauthorizedAccessException();

        cachedRefreshToken = refreshGenerator.Create();
        var sevenDaysInMinutes = 10080;
        await cache.SetStringAsync($"user:{userIdFromAccessToken}:refresh-token", cachedRefreshToken, sevenDaysInMinutes, cancellationToken);

        var user = await context.Users.FindByIdAsync(userIdFromAccessToken, cancellationToken)
            ?? throw new UserNotFoundException("not found.");

        var claims = claimsFactory.Create(user);
        var accessToken = jwtFactory.Create(claims);

        var response = new AccessTokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = cachedRefreshToken
        };

        return response;
    }

}
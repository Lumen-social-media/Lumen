using Lumen.Identity.Application.Common;
using Lumen.Identity.Application.Common.Auth;
using Lumen.Identity.Application.Common.Auth.Jwt;
using Lumen.Identity.Application.Common.Caching;
using Lumen.Identity.Application.Users.Exceptions;
using Lumen.Identity.Domain.Users.ValueObjects.Email;
using Lumen.Identity.UseCase.Common;
using Lumen.Identity.UseCase.Users.Extensions;

namespace Lumen.Identity.Application.Users.Commands;

public sealed class LoginUserWithJwtCommand : ICommand<AccessTokenResponse>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public sealed class LoginUserWithJwtCommandHandler(IApplicationDbContext context,
                                                   JwtFactory jwtFactory,
                                                   ClaimsFactory claimsFactory,
                                                   RefreshTokenGenerator refreshTokenGenerator,
                                                   PasswordHasher passwordHasher,
                                                   ICache cache) : ICommandHandler<LoginUserWithJwtCommand, AccessTokenResponse>
{
    public async Task<AccessTokenResponse> Handle(LoginUserWithJwtCommand command, CancellationToken cancellationToken)
    {
        var email = Email.Create(command.Email);
        var user = await context.Users.FindByEmailAsync(email, cancellationToken)
            ?? throw new UserNotFoundException(command.Email);

        if (user.PasswordHash != passwordHasher.Hash(command.Password))
            throw new NotRightPasswordException(command.Password);

        var claims = claimsFactory.Create(user);
        var jwtToken = jwtFactory.Create(claims);
        var refreshToken = await cache.GetStringAsync($"user:{user.Id}:refresh-token", cancellationToken);

        if (refreshToken is null)
        {
            refreshToken = refreshTokenGenerator.Create();
            var sevenDaysInMinutes = 10080;
            await cache.SetStringAsync($"user:{user.Id}:refresh-token", refreshToken, sevenDaysInMinutes, cancellationToken);
        }

        var response = new AccessTokenResponse
        {
            AccessToken = jwtToken,
            RefreshToken = refreshToken
        };

        return response;
    }
}
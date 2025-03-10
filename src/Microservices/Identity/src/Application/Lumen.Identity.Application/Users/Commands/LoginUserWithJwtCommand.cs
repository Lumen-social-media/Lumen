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
                                                   ICache cache) : ICommandHandler<LoginUserWithJwtCommand, AccessTokenResponse>
{
    public async Task<AccessTokenResponse> Handle(LoginUserWithJwtCommand command, CancellationToken cancellationToken)
    {
        var email = Email.Create(command.Email);
        var user = await context.Users.FindByEmailAsync(email, cancellationToken)
            ?? throw new UserNotFoundException(command.Email);

        var claims = claimsFactory.Create(user);
        var jwtToken = jwtFactory.Create(claims);
        var refreshToken = refreshTokenGenerator.Create();

        await cache.SetStringAsync($"user:{refreshToken}", user.Id.ToString());

        var response = new AccessTokenResponse
        {
            AccessToken = jwtToken,
            RefreshToken = refreshToken
        };

        return response;
    }
}
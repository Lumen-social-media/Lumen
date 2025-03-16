using Lumen.Identity.Application.Common;
using Lumen.Identity.Application.Common.Auth;
using Lumen.Identity.Application.Common.Auth.Jwt;
using Lumen.Identity.Application.Common.Caching;
using Lumen.Identity.Application.Common.EventBus;
using Lumen.Identity.Application.Users.Exceptions;
using Lumen.Identity.Application.Users.Mappers.Extensions;
using Lumen.Identity.Domain.Users;
using Lumen.Identity.Domain.Users.ValueObjects.Email;
using Lumen.Identity.UseCase.Common;
using Lumen.Identity.UseCase.Users.Extensions;

namespace Lumen.Identity.Application.Users.Commands;

public sealed class RegisterUserWithJwtCommand : ICommand<AccessTokenResponse>
{
    public required string UserName { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public DateOnly? BirthDate { get; set; }
    public string Hometown { get; set; } = string.Empty;
    public Language Language { get; set; } = Language.NotSet;
    public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.NotSet;
    public string CurrentCity { get; set; } = string.Empty;
    public string PersonalSite { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.NotSet;
    public string SchoolName { get; set; } = string.Empty;
    public bool HasPublicProfile { get; set; }
}

public sealed class RegisterUserWithJwtCommandHandler(IApplicationDbContext context,
                                                      IEventBus bus,
                                                      JwtFactory jwtFactory,
                                                      ClaimsFactory claimsFactory,
                                                      RefreshTokenGenerator refreshTokenGenerator,
                                                      PasswordHasher passwordHasher,
                                                      ICache cache) : ICommandHandler<RegisterUserWithJwtCommand, AccessTokenResponse>
{
    public async Task<AccessTokenResponse> Handle(RegisterUserWithJwtCommand command, CancellationToken cancellationToken)
    {
        var email = Email.Create(command.Email);
        var user = await context.Users.FindByEmailAsync(email, cancellationToken);

        if (user is not null)
            throw new UserAlreadyExistsException(command.Email);

        var passwordHash = passwordHasher.Hash(command.Password);
        user = command.ToUser(passwordHash);

        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var claims = claimsFactory.Create(user);
        var accessToken = jwtFactory.Create(claims);
        var refreshToken = refreshTokenGenerator.Create();
        var sevenDaysInMinutes = 10080;

        await cache.SetStringAsync($"user:{user.Id}:refresh-token", refreshToken, sevenDaysInMinutes, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var response = new AccessTokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        var message = user.ToUserRegisteredMessage();

        await bus.PublishAsync(message, cancellationToken);

        return response;
    }

}

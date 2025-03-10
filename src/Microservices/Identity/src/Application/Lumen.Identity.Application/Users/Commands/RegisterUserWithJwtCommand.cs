using Lumen.Identity.Application.Common;
using Lumen.Identity.Application.Common.Auth;
using Lumen.Identity.Application.Common.Auth.Jwt;
using Lumen.Identity.Application.Common.Caching;
using Lumen.Identity.Application.Common.EventBus;
using Lumen.Identity.Application.Users.Cache;
using Lumen.Identity.Application.Users.Exceptions;
using Lumen.Identity.Application.Users.Messages;
using Lumen.Identity.Domain.Users;
using Lumen.Identity.Domain.Users.ValueObjects.About;
using Lumen.Identity.Domain.Users.ValueObjects.Email;
using Lumen.Identity.Domain.Users.ValueObjects.LastName;
using Lumen.Identity.Domain.Users.ValueObjects.Name;
using Lumen.Identity.Domain.Users.ValueObjects.Surname;
using Lumen.Identity.Domain.Users.ValueObjects.UserName;
using Lumen.Identity.UseCase.Common;
using Lumen.Identity.UseCase.Users.Extensions;

namespace Lumen.Identity.Application.Users.Commands;

public sealed class RegisterUserWithJwtCommand : ICommand<AccessTokenResponse>
{
    public required string UserName { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
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
                                                      ICache cache,
                                                      IUserCache userCache) : ICommandHandler<RegisterUserWithJwtCommand, AccessTokenResponse>
{
    public async Task<AccessTokenResponse> Handle(RegisterUserWithJwtCommand command, CancellationToken cancellationToken)
    {
        var email = Email.Create(command.Email);
        var user = await context.Users.FindByEmailAsync(email, cancellationToken);

        if (user is not null)
            throw new UserAlreadyExistsException(command.Email);

        user = await CreateUser(command, cancellationToken);

        var claims = claimsFactory.Create(user);
        var accessToken = jwtFactory.Create(claims);
        var refreshToken = refreshTokenGenerator.Create();

        await cache.SetStringAsync($"user:{refreshToken}", user.Id.ToString());
        await context.SaveChangesAsync(cancellationToken);
        
        var response = new AccessTokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        var message = new UserRegisteredMessage(user.Id, user.UserName.Value, user.Name.Value, user.Surname.Value, user.Email.Value, user.LastName.Value, user.About.Description, user.About.AvatarUrl, user.About.BirthDate, user.RegistrationDate, user.LastLoginAt, user.About.Hometown, user.About.Language, user.About.MaritalStatus, user.About.CurrentCity, user.About.PersonalSite, user.About.Gender, user.About.SchoolName, user.About.HasPublicProfile);
        await bus.PublishAsync(message, cancellationToken);

        return response;
    }

    private async Task<User> CreateUser(RegisterUserWithJwtCommand command, CancellationToken cancellationToken = default)
    {
        var userName = UserName.Create(command.UserName);
        var name = Name.Create(command.Name);
        var surname = Surname.Create(command.Surname);
        var lastName = LastName.Create(command.LastName);
        var email = Email.Create(command.Email);
        var about = About.Create(command.Description, command.AvatarUrl, command.Hometown, command.BirthDate, command.Language, command.MaritalStatus, command.CurrentCity, command.PersonalSite, command.Gender, command.SchoolName, command.HasPublicProfile);
        var user = User.Create(userName, name, surname, lastName, email, about);
        var createdUser = await context.Users.AddAsync(user, cancellationToken);
        user = createdUser.Entity;

        return user;
    }
}

using Lumen.Users.Domain.Aggregates.Users;
using Lumen.Users.Domain.Aggregates.Users.Dtos;
using Lumen.Users.UseCases;
using Mapster;

namespace Lumen.Users.Application.Aggregates.Users.Commands;

public sealed record CreateUserCommand : ICommand<UserResponse>
{
    public required string UserName { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
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
    public bool OnlyRegisteredUsersCanViewProfile { get; set; }
}

public sealed class CreateUserCommandHandler(IApplicationContext context) : ICommandHandler<CreateUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var dto = command.Adapt<CreateUserDto>();
        var user = User.Create(dto);

        var createdUser = await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var response = createdUser.Adapt<UserResponse>();

        return response;
    }
}

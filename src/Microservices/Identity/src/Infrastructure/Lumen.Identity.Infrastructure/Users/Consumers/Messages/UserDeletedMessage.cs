namespace Lumen.Identity.Infrastructure.Users.Consumers.Messages;

public sealed record UserDeletedMessage
{
    public required Guid Id { get; set; }
}

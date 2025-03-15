using Lumen.Profile.Application.Common.Exceptions;

namespace Lumen.Profile.Application.Aggregates.Users.Entities.Posts.Exceptions;

public sealed class PostNotFoundException(Guid id) : NotFoundException($"Post with id '{id}' not found.")
{
}

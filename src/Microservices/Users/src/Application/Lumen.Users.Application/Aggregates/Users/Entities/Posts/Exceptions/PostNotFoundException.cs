using Lumen.Users.Application.Common.Exceptions;

namespace Lumen.Users.Application.Aggregates.Users.Entities.Posts.Exceptions;

public sealed class PostNotFoundException(int id) : NotFoundException($"Post with id '{id}' not found.")
{
}

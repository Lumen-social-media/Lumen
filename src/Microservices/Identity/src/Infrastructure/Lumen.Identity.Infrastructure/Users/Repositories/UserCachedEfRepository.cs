using Lumen.Identity.Application.Common.Caching;
using Lumen.Identity.Application.Users.Repositories;
using Lumen.Identity.Domain.Users;
using Lumen.Identity.Domain.Users.ValueObjects.Email;
using Lumen.Identity.UseCase.Common;
using System.Text.Json;

namespace Lumen.Identity.Infrastructure.Users.Repositories;

public sealed class UserCachedEfRepository(IApplicationDbContext context, ICache cache) : IUserCachedRepository
{
    public async Task<User> AddAsync(User user, CancellationToken cancellationToken = default)
    {
        var createdUser = await context.Users.AddAsync(user, cancellationToken);
        await cache.SetStringAsync($"user:{createdUser.Entity.Id}", JsonSerializer.Serialize(createdUser.Entity), 0.3, cancellationToken);

        return createdUser.Entity;
    }

    public async Task<User?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        string? cachedUser = await cache.GetStringAsync($"user:{id}", cancellationToken);
        User? user = null;

        if (cachedUser is null)
        {
            user = await context.Users.FindAsync([id], cancellationToken);

            if (user is null) return null;

            await cache.SetStringAsync($"user:{user.Id}", JsonSerializer.Serialize(user), 0.3, cancellationToken);

            return user;
        }


        return user;
    }

    public void Remove(User user, CancellationToken cancellationToken = default)
    {
        context.Users.Remove(user);
    }
}

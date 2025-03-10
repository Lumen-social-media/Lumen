using Lumen.Identity.Application.Users.Cache;
using Lumen.Identity.Domain.Users;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Lumen.Identity.Infrastructure.Users.Cache;

public sealed class UserRedisDistributedCache(IDistributedCache cache) : IUserCache
{
    public async Task<User?> GetAsync(string key, CancellationToken cancellationToken = default)
    {
        var result = await cache.GetStringAsync(key, cancellationToken);

        if (result is null) return null;

        return JsonSerializer.Deserialize<User>(result);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await cache.RemoveAsync(key, cancellationToken);
    }

    public async Task SetAsync(User entity, CancellationToken cancellationToken = default)
    {
        var options = new DistributedCacheEntryOptions();
        var serializedUser = JsonSerializer.Serialize(entity);
        await cache.SetStringAsync($"user:{entity.Id}", serializedUser, cancellationToken);

        throw new NotImplementedException();
    }
}

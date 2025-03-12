using Lumen.Identity.Application.Common.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Lumen.Identity.Infrastructure.Common.Caching;

public sealed class RedisDistributedCache(IDistributedCache cache) : ICache
{
    public async Task SetStringAsync(string key, string value, double expirationMinutes, CancellationToken cancellationToken = default)
    {
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(expirationMinutes)
        };

        await cache.SetStringAsync(key, value, options, cancellationToken);
    }

    public async Task<string?> GetStringAsync(string key, CancellationToken cancellationToken = default)
    {
        var value = await cache.GetStringAsync(key, cancellationToken);


        return value;
    }

    public async Task Remove(string key, CancellationToken cancellationToken = default)
    {
        await cache.RemoveAsync(key, cancellationToken);
    }
}

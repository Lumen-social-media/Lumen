using Lumen.Identity.Application.Common.Caching;
using Microsoft.Extensions.Caching.Distributed;

namespace Lumen.Identity.Infrastructure.Common.Caching;

public sealed class RedisDistributedCache(IDistributedCache cache) : ICache
{
    public async Task SetStringAsync(string key, string value)
    {
        var options = new DistributedCacheEntryOptions();

        await cache.SetStringAsync(key, value, options);
    }

    public async Task<string?> GetStringAsync(string key, CancellationToken cancellationToken = default)
    {
        var value = await cache.GetStringAsync(key, cancellationToken);

        return value;
    }

    public string Remove(string key)
    {
        throw new NotImplementedException();
    }
}

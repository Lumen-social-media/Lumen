namespace Lumen.Identity.Application.Common.Caching;

public interface ICache
{
    public Task<string?> GetStringAsync(string key, CancellationToken cancellationToken = default);
    public Task Remove(string key, CancellationToken cancellationToken = default);
    public Task SetStringAsync(string key, string value, double expirationMinutes, CancellationToken cancellationToken = default);
}

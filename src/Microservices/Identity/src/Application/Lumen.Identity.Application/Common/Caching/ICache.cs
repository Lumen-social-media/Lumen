namespace Lumen.Identity.Application.Common.Caching;

public interface ICache
{
    public Task<string?> GetStringAsync(string key, CancellationToken cancellationToken = default);
    public string Remove(string key);
    public Task SetStringAsync(string key, string value);
}

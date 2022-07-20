using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace ConferenceModule.ApiCms.Services;

public class ResponseCacheService : IResponseCacheService {
    private readonly IDistributedCache _distributedCache;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ResponseCacheService(IDistributedCache distributedCache) {
        _distributedCache = distributedCache;
        _jsonSerializerOptions = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task CacheResponseAsync(string cacheKey, object? response) {
        if (response == null) return;

        var serializedResponse = JsonSerializer.Serialize(response, _jsonSerializerOptions);
        await _distributedCache.SetStringAsync(cacheKey, serializedResponse);
    }

    public async Task CacheResponseAsync(string cacheKey, object? response, TimeSpan timeTimeLive) {
        if (response == null) return;

        var serializedResponse = JsonSerializer.Serialize(response, _jsonSerializerOptions);

        await _distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions {
            AbsoluteExpirationRelativeToNow = timeTimeLive
        });
    }

    public async Task<string> GetCachedResponseAsync(string cacheKey) {
        var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);
        return (string.IsNullOrEmpty(cachedResponse) ? null : cachedResponse)!;
    }
}
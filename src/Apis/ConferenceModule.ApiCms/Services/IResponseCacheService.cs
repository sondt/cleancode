namespace ConferenceModule.ApiCms.Services;

public interface IResponseCacheService {
    Task CacheResponseAsync(string cacheKey, object? response);
    Task CacheResponseAsync(string cacheKey, object? response, TimeSpan timeTimeLive);

    Task<string> GetCachedResponseAsync(string cacheKey);
}
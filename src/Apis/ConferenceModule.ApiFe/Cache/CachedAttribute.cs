using System.Diagnostics.CodeAnalysis;
using System.Text;
using ConferenceModule.ApiFe.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConferenceModule.ApiFe.Cache;

[SuppressMessage("ReSharper", "TooManyChainedReferences")]
[SuppressMessage("ReSharper", "MethodTooLong")]
public class CachedAttribute : Attribute, IAsyncActionFilter {
    private readonly int _timeToLiveSeconds;

    public CachedAttribute(int timeToLiveSeconds) {
        _timeToLiveSeconds = timeToLiveSeconds;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
        var cacheSettings = context.HttpContext.RequestServices.GetRequiredService<RedisCacheSettings>();

        if (!cacheSettings.Enabled) {
            await next();
            return;
        }

        var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();

        var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
        var cachedResponse = await cacheService.GetCachedResponseAsync(cacheKey);
        var clearCache = context.HttpContext.Request.Headers["clear-cache"].ToString();
        
        if (!string.IsNullOrEmpty(cachedResponse) && !clearCache.Equals("true")) {
            var contentResult = new ContentResult {
                Content = cachedResponse,
                ContentType = "application/json",
                StatusCode = 200
            };
            context.Result = contentResult;
            return;
        }

        var executedContext = await next();

        if (executedContext.Result is OkObjectResult okObjectResult) {
            if (_timeToLiveSeconds > 0)
                await cacheService.CacheResponseAsync(cacheKey, okObjectResult.Value,
                    TimeSpan.FromSeconds(_timeToLiveSeconds));
            else
                await cacheService.CacheResponseAsync(cacheKey, okObjectResult.Value);
        }
    }

    private static string GenerateCacheKeyFromRequest(HttpRequest request) {
        var keyBuilder = new StringBuilder();

        keyBuilder.Append($"{request.Path}");

        foreach (var (key, value) in request.Query.OrderBy(x => x.Key)) keyBuilder.Append($"|{key}-{value}");

        return keyBuilder.ToString();
    }
}
using ConferenceModule.ApiCms.Cache;
using ConferenceModule.ApiCms.Services;
using StackExchange.Redis;

namespace ConferenceModule.ApiCms.Installers;

public class CacheInstaller : IInstaller {
    public void InstallServices(IServiceCollection services, IConfiguration configuration) {
        var redisCacheSettings = new RedisCacheSettings();
        configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
        services.AddSingleton(redisCacheSettings);

        if (!redisCacheSettings.Enabled) return;

        services.AddSingleton<IConnectionMultiplexer>(_ =>
            ConnectionMultiplexer.Connect(redisCacheSettings.ConnectionString));
        services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSettings.ConnectionString);
        services.AddSingleton<IResponseCacheService, ResponseCacheService>();
    }
}
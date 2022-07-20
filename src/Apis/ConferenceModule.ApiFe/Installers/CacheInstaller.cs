using ConferenceModule.ApiFe.Cache;
using ConferenceModule.ApiFe.Services;
using StackExchange.Redis;

namespace ConferenceModule.ApiFe.Installers;

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
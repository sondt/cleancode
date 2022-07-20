using ConferenceModule.Application;
using ConferenceModule.Application.Common.Message;
using ConferenceModule.Application.Common.Settings;
using ConferenceModule.Application.Common.Settings.Backend;
using ConferenceModule.SqlPersistence;
using Microsoft.Net.Http.Headers;

namespace ConferenceModule.ApiFe.Services;

public static class RegistrationServices {
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddPersistenceServices(configuration);
        services.AddApplicationServices(configuration);

        //bind settings
        var settings = new List<object> {
            new AccountMessage(),
            new JwtSetting(),
            new ApiFrontend(),
            new ConferenceMessage(),
            new ConferencePermissionMessage(),
            new ApplicationSetting()
        };
        foreach (var setting in settings) {
            configuration.Bind(setting.GetType().Name, setting);
            services.AddSingleton(setting);
        }
    }
}
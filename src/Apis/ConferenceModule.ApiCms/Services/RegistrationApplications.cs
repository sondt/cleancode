using ConferenceModule.Application.Common.Middlewares;
using Serilog;

namespace ConferenceModule.ApiCms.Services;

public static class RegistrationApplications {
    public static WebApplication RegisterApplications(this WebApplication application) {
        //config serilog
        var builder = WebApplication.CreateBuilder();
        builder.Host.UseSerilog((context, services, configuration) => configuration.ReadFrom
            .Configuration(context.Configuration).ReadFrom.Services(services).Enrich.FromLogContext());

        //custom handler exception
        application.ConfigureExceptionHandler();
        return application;
    }
}
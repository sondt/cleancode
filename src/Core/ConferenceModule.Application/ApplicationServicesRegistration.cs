using System.Reflection;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Application.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace ConferenceModule.Application;

public static class ApplicationServicesRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration) {
        services.AddHttpClient();
        services.AddScoped<IHttpService, HttpService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddSingleton<IConferenceHub, ConferenceHub>();
        return services;
    }
}
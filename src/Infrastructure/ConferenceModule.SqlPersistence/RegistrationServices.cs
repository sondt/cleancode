using ConferenceModule.Application.Common;
using ConferenceModule.Application.Contracts.Accounts;
using ConferenceModule.Application.Contracts.ConferenceGuests;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.SqlPersistence.Accounts;
using ConferenceModule.SqlPersistence.ConferenceDetails;
using ConferenceModule.SqlPersistence.Conferences;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConferenceModule.SqlPersistence;

public static class RegistrationServices {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration) {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<MediaContext>(option => option.UseSqlServer(connectionString));
        services.AddScoped<IConferenceRepository, ConferenceRepository>();
        services.AddScoped<IConferenceDetailRepository, ConferenceDetailRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IConferenceGuestRepository, ConferenceGuestRepository>();
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        return services;
    }
}
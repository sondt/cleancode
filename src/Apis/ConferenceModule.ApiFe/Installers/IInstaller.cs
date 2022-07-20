namespace ConferenceModule.ApiFe.Installers;

public interface IInstaller {
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}
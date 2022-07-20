namespace ConferenceModule.ApiCms.Installers;

public interface IInstaller {
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}
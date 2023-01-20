namespace CleanArchitectureAccountingApp.WebAPI.Configurations;

public interface IServiceInstaller
{
    void Install(IServiceCollection serviceCollection, IConfiguration configuration);
}
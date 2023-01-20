using CleanArchitectureAccountingApp.Application.Abstractions;
using CleanArchitectureAccountingApp.Infrastructure.Authhentication;

namespace CleanArchitectureAccountingApp.WebAPI.Configurations;

public class InfrastructureDIServiceInstaller: IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<IJwtProvider, JwtProvider>();
    }
}
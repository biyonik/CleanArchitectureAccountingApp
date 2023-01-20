using CleanArchitectureAccountingApp.WebAPI.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CleanArchitectureAccountingApp.WebAPI.Configurations;

public class AuthenticationAndAuthorizationServiceInstaller: IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.ConfigureOptions<JwtOptionsSetup>();
        serviceCollection.ConfigureOptions<JwtBearerOptionsSetup>();

        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
    }
}
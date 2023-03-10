using CleanArchitectureAccountingApp.Application.Behaviour;
using FluentValidation;
using MediatR;

namespace CleanArchitectureAccountingApp.WebAPI.Configurations;

public class ThirdPartyServiceInstaller: IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediatR(typeof(CleanArchitectureAccountingApp.Application.AssemblyReference).Assembly);
        serviceCollection.AddAutoMapper(typeof(CleanArchitectureAccountingApp.Persistence.AssemblyReference).Assembly);
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehaviour<,>)));
        serviceCollection.AddValidatorsFromAssembly(typeof(CleanArchitectureAccountingApp.Application.AssemblyReference)
            .Assembly);
    }
}
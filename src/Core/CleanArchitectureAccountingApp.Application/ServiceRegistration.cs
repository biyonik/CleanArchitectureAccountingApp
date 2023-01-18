using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureAccountingApp.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServiceRegistration).Assembly);
        return services;
    }
}
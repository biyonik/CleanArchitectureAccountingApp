using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using CleanArchitectureAccountingApp.Persistence.Context;

namespace CleanArchitectureAccountingApp.WebAPI.Configurations;

public class PersistenceServiceInstaller: IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddControllers()
            .AddApplicationPart(typeof(CleanArchitectureAccountingApp.Presentation.AssemblyReference).Assembly);
        serviceCollection.AddDbContext<AppDbContext>();
        serviceCollection.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();
    }
}
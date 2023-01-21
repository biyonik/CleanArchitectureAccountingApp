using CleanArchitectureAccountingApp.Application.Services.AppServices.CompanyService;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Application.Services.CompanyServices;
using CleanArchitectureAccountingApp.Domain;
using CleanArchitectureAccountingApp.Domain.Repositories.UniformChartOfAccountRepositories;
using CleanArchitectureAccountingApp.Persistence;
using CleanArchitectureAccountingApp.Persistence.Repositories.UniformChartOfAccount;
using CleanArchitectureAccountingApp.Persistence.Services.AppServices;
using CleanArchitectureAccountingApp.Persistence.Services.CompanyServices;

namespace CleanArchitectureAccountingApp.WebAPI.Configurations;

public class PersistenceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        #region ContextAndUnitOfWork

        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<IContextService, ContextService>();

        #endregion

        #region Services

        serviceCollection.AddScoped<ICompanyService, CompanyService>();
        serviceCollection.AddScoped<IUniformChartOfAccountService, UniformChartOfAccountService>();
        serviceCollection.AddScoped<IRoleService, RoleService>();

        #endregion

        #region Repositories

        serviceCollection.AddScoped<IUniformChartOfAccountQueryRepository, UniformChartOfAccountQueryRepository>();
        serviceCollection.AddScoped<IUniformChartOfAccountCommandRepository, UniformChartOfAccountCommandRepository>();

        #endregion
    }
}
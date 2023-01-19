using CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using CleanArchitectureAccountingApp.Domain.AppEntities;

namespace CleanArchitectureAccountingApp.Application.Services.AppServices.CompanyService;

public interface ICompanyService
{
    Task<bool> Create(CreateCompanyRequest request);
    Task<Company?> GetCompanyByName(string name);
    Task<bool> MigrateCompanyDatabases();
}
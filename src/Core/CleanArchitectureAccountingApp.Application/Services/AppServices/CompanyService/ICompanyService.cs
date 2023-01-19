using CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

namespace CleanArchitectureAccountingApp.Application.Services.AppServices.CompanyService;

public interface ICompanyService
{
    Task<bool> Create(CreateCompanyRequest request);
}
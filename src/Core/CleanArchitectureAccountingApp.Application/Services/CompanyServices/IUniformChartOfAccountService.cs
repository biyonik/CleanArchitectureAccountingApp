using CleanArchitectureAccountingApp.Application.DTOs.CompaniesSubDTOs.UniformChartOfAccount;

namespace CleanArchitectureAccountingApp.Application.Services.CompanyServices;

public interface IUniformChartOfAccountService
{
    Task<bool> CreateUniformChartOfAccountAsync(UniformChartOfAccountForAddDto request, CancellationToken cancellationToken);
}
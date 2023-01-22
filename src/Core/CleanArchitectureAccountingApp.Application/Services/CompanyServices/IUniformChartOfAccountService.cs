using CleanArchitectureAccountingApp.Application.DTOs.CompaniesSubDTOs.UniformChartOfAccount;
using CleanArchitectureAccountingApp.Domain.CompanyEntities;

namespace CleanArchitectureAccountingApp.Application.Services.CompanyServices;

public interface IUniformChartOfAccountService
{
    Task<bool> CreateUniformChartOfAccountAsync(UniformChartOfAccountForAddDto request, CancellationToken cancellationToken);
    Task<UniformChartOfAccount?> GetByCode(string code);
}
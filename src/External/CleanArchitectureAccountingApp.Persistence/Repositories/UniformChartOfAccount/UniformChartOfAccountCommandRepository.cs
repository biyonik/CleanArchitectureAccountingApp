using CleanArchitectureAccountingApp.Domain.Repositories.UniformChartOfAccountRepositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Persistence.Repositories.UniformChartOfAccount;

public sealed class UniformChartOfAccountCommandRepository:
    CommandRepository<Domain.CompanyEntities.UniformChartOfAccount>, IUniformChartOfAccountCommandRepository
{
    
}
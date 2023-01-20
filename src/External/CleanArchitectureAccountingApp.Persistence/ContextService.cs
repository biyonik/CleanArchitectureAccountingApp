using CleanArchitectureAccountingApp.Domain;
using CleanArchitectureAccountingApp.Domain.AppEntities;
using CleanArchitectureAccountingApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Persistence;

public sealed class ContextService: IContextService
{
    private readonly AppDbContext _appDbContext;

    public ContextService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public DbContext CreateDbContextInstance(Guid companyId)
    {
        Company? company = _appDbContext.Set<Company>().Find(companyId);
        return new CompanyDbContext(company);
    }
}
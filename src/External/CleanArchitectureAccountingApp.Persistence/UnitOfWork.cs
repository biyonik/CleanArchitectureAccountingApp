using CleanArchitectureAccountingApp.Domain;
using CleanArchitectureAccountingApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Persistence;

public sealed class UnitOfWork: IUnitOfWork
{
    private CompanyDbContext _ctx;
    public void SetDbContextInstance(DbContext ctx)
    {
        _ctx = (CompanyDbContext)ctx;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _ctx.SaveChangesAsync(cancellationToken);
    }
}
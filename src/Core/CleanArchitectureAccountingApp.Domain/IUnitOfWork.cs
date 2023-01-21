using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Domain;

public interface IUnitOfWork
{
    void SetDbContextInstance(DbContext ctx);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Domain;

public interface IContextService
{
    DbContext CreateDbContextInstance(Guid companyId);
}
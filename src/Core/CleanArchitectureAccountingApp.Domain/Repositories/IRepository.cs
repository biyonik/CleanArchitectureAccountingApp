using CleanArchitectureAccountingApp.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Domain.Repositories;

public interface IRepository<TEntity>
where TEntity: Entity
{
    DbSet<TEntity> Entity { get;}
    void SetDbContextInstance(DbContext ctx);
}
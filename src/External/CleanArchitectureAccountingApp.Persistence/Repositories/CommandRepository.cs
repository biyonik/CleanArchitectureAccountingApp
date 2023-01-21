using CleanArchitectureAccountingApp.Domain.Abstractions;
using CleanArchitectureAccountingApp.Domain.Repositories;
using CleanArchitectureAccountingApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Persistence.Repositories;

public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : Entity
{
    private CompanyDbContext _ctx;
    public DbSet<TEntity> Entity { get; set; }

    private static readonly Func<CompanyDbContext, Guid, Task<TEntity?>> GetByIdCompiledQuery
        = EF.CompileAsyncQuery((CompanyDbContext context, Guid Id) =>
            context.Set<TEntity>().FirstOrDefault(x => x.Id == Id));

    public void SetDbContextInstance(DbContext ctx)
    {
        _ctx = (CompanyDbContext)ctx;
        Entity = _ctx.Set<TEntity>();
    }

    public async Task AddAsync(TEntity? entity, CancellationToken cancellationToken)
    {
        await Entity.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity?> entities, CancellationToken cancellationToken)
    {
        await Entity.AddRangeAsync(entities, cancellationToken);
    }

    public async Task UpdateAsync(TEntity? entity, CancellationToken cancellationToken)
    {
        await Task.Run(() => Entity.Update(entity), cancellationToken);
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity?> entities, CancellationToken cancellationToken)
    {
        await Task.Run(() => Entity.UpdateRange(entities), cancellationToken);
    }

    public async Task RemoveByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var entityFormRemove = await GetByIdCompiledQuery(_ctx, Id);
        if (entityFormRemove == null) return;
        await Task.Run(() => Entity.Remove(entityFormRemove), cancellationToken);
    }

    public async Task Remove(TEntity? entity, CancellationToken cancellationToken)
    {
        await Task.Run(() => Entity.Remove(entity), cancellationToken);
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity?> entities, CancellationToken cancellationToken)
    {
        await Task.Run(() => Entity.RemoveRange(entities), cancellationToken);
    }
}
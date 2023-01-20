using System.Linq.Expressions;
using CleanArchitectureAccountingApp.Domain.Abstractions;
using CleanArchitectureAccountingApp.Domain.Repositories;
using CleanArchitectureAccountingApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Persistence.Repositories;

public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : Entity
{
    private CompanyDbContext _ctx;
    public DbSet<TEntity> Entity { get; set; }

    private static readonly Func<CompanyDbContext, bool, Task<TEntity?>> GetFirstCompiledQuery
        = EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking) =>
            isTracking
                ? context.Set<TEntity>().AsNoTracking().FirstOrDefault()
                : context.Set<TEntity>().FirstOrDefault());

    private static readonly Func<CompanyDbContext, Expression<Func<TEntity, bool>>, bool, Task<TEntity?>>
        GetAsyncCompiledQuery
            = EF.CompileAsyncQuery(
                (CompanyDbContext context, Expression<Func<TEntity, bool>> expression, bool isTracking) =>
                    isTracking
                        ? context.Set<TEntity>().AsNoTracking().FirstOrDefault(expression)
                        : context.Set<TEntity>().FirstOrDefault(expression));

    public void SetDbContextInstance(DbContext ctx)
    {
        _ctx = (CompanyDbContext)ctx;
        Entity = _ctx.Set<TEntity>();
    }

    public async Task<IQueryable<TEntity?>> GetAllAsync(bool isTracking = true)
    {
        return !isTracking
            ? await Task.Run(() => Entity.AsQueryable().AsNoTracking())
            : await Task.Run(() => Entity.AsQueryable());
    }

    public async Task<IQueryable<TEntity?>> GetAllByWhereExpression(Expression<Func<TEntity?, bool>> expression,
        bool isTracking = true)
    {
        return !isTracking
            ? await Task.Run(() => Entity.Where(expression).AsQueryable().AsNoTracking())
            : await Task.Run(() => Entity.Where(expression).AsQueryable());
    }

    public async Task<TEntity?> GetByIdAsync(Guid Id, bool isTracking = true)
    {
        return !isTracking
            ? await Entity.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id)
            : await Entity.FindAsync(Id);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool isTracking = true)
    {
        return await GetAsyncCompiledQuery(_ctx, expression, isTracking);
    }

    public async Task<TEntity?> GetFirstAsync(bool isTracking = true)
    {
        return await GetFirstCompiledQuery(_ctx, isTracking);
    }
}
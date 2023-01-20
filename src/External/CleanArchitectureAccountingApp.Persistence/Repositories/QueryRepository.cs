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
    
    private static readonly Func<CompanyDbContext, Task<TEntity?>> GetFirstCompiledQuery
    = EF.CompileAsyncQuery((CompanyDbContext context) => 
        context.Set<TEntity>().FirstOrDefault());
    
    private static readonly Func<CompanyDbContext, Expression<Func<TEntity, bool>>, Task<TEntity?>> GetAsyncCompiledQuery
        = EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<TEntity, bool>> expression) => 
            context.Set<TEntity>().FirstOrDefault(expression));

    public void SetDbContextInstance(DbContext ctx)
    {
        _ctx = (CompanyDbContext)ctx;
        Entity = _ctx.Set<TEntity>();
    }

    public async Task<IQueryable<TEntity?>> GetAllAsync()
    {
        return await Task.Run(() => Entity.AsQueryable());
    }

    public async Task<IQueryable<TEntity?>> GetAllByWhereExpression(Expression<Func<TEntity?, bool>> expression)
    {
        return await Task.Run(() => Entity.Where(expression).AsQueryable());
    }

    public async Task<TEntity?> GetByIdAsync(Guid Id)
    {
        return await Entity.FindAsync(Id);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await GetAsyncCompiledQuery(_ctx, expression);
    }

    public async Task<TEntity?> GetFirstAsync()
    {
        return await GetFirstCompiledQuery(_ctx);
    }
}
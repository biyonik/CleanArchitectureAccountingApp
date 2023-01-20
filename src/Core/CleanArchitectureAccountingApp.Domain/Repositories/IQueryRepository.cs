using System.Linq.Expressions;
using CleanArchitectureAccountingApp.Domain.Abstractions;

namespace CleanArchitectureAccountingApp.Domain.Repositories;

public interface IQueryRepository<TEntity> : IRepository<TEntity> where TEntity: Entity
{
    Task<IQueryable<TEntity?>> GetAllAsync();
    Task<IQueryable<TEntity?>> GetAllByWhereExpression(Expression<Func<TEntity?, bool>> expression);
    Task<TEntity?> GetByIdAsync(Guid Id);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity?> GetFirstAsync();
}
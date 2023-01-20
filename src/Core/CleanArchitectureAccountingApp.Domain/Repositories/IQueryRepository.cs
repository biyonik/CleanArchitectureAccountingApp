using System.Linq.Expressions;
using CleanArchitectureAccountingApp.Domain.Abstractions;

namespace CleanArchitectureAccountingApp.Domain.Repositories;

public interface IQueryRepository<TEntity> : IRepository<TEntity> where TEntity: Entity
{
    Task<IQueryable<TEntity?>> GetAllAsync(bool isTracking = true);
    Task<IQueryable<TEntity?>> GetAllByWhereExpression(Expression<Func<TEntity?, bool>> expression, bool isTracking = true);
    Task<TEntity?> GetByIdAsync(Guid Id, bool isTracking = true);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool isTracking = true);
    Task<TEntity?> GetFirstAsync(bool isTracking = true);
}
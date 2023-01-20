using CleanArchitectureAccountingApp.Domain.Abstractions;

namespace CleanArchitectureAccountingApp.Domain.Repositories;

public interface ICommandRepository<TEntity> : IRepository<TEntity> where TEntity: Entity
{
    Task AddAsync(TEntity? entity);
    Task AddRangeAsync(IEnumerable<TEntity?> entities);
    Task UpdateAsync(TEntity? entity);
    Task UpdateRangeAsync(IEnumerable<TEntity?> entities);
    Task RemoveByIdAsync(Guid Id);
    Task Remove(TEntity? entity);
    Task RemoveRangeAsync(IEnumerable<TEntity?> entities);
}
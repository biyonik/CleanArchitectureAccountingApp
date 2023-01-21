using CleanArchitectureAccountingApp.Domain.Abstractions;

namespace CleanArchitectureAccountingApp.Domain.Repositories;

public interface ICommandRepository<TEntity> : IRepository<TEntity> where TEntity: Entity
{
    Task AddAsync(TEntity? entity, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<TEntity?> entities, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity? entity, CancellationToken cancellationToken);
    Task UpdateRangeAsync(IEnumerable<TEntity?> entities, CancellationToken cancellationToken);
    Task RemoveByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task Remove(TEntity? entity, CancellationToken cancellationToken);
    Task RemoveRangeAsync(IEnumerable<TEntity?> entities, CancellationToken cancellationToken);
}
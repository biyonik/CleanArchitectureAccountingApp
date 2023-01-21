using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

namespace CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;

public interface IRoleService
{
    Task AddAsync(CreateRole.Command request);
    Task UpdateAsync(UpdateRole.Command request);
    Task DeleteAsync(DeleteRole.Command request);
    Task<IReadOnlyList<AppRole?>> GetAllAsync();
    Task<AppRole?> GetById(string Id);
    Task<AppRole?> GetByCode(string Code);
}
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

namespace CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;

public interface IRoleService
{
    Task AddAsync(CreateRoleRequest request);
    Task UpdateAsync(UpdateRoleRequest request);
    Task DeleteAsync(DeleteRole.DeleteRoleRequest request);
    Task<IReadOnlyList<AppRole?>> GetAllAsync();
    Task<AppRole?> GetById(string Id);
    Task<AppRole?> GetByCode(string Code);
}
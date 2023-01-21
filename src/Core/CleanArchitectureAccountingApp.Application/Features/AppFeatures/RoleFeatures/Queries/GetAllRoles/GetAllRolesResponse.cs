using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;

public sealed class GetAllRolesResponse
{
    public IReadOnlyList<AppRole> Roles { get; set; }
}
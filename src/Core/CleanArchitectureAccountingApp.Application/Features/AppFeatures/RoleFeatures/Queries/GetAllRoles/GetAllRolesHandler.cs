using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;

public class GetAllRolesHandler : IRequestHandler<GetAllRolesRequest, GetAllRolesResponse>
{
    private readonly RoleManager<AppRole> _roleManager;

    public GetAllRolesHandler(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<GetAllRolesResponse> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyList<AppRole> roles = await _roleManager.Roles.ToListAsync(cancellationToken: cancellationToken);
        return new GetAllRolesResponse { Roles = roles };
    }
}
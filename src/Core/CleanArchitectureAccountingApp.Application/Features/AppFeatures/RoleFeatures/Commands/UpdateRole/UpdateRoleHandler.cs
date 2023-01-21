using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using MediatR;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, UpdateRoleResponse>
{
    private readonly IRoleService _roleService;

    public UpdateRoleHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<UpdateRoleResponse> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        AppRole? currentRole = await _roleService.GetById(request.Id.ToString());
        if (currentRole == null) throw new Exception("Role bulunamadı");

        if (currentRole.Code != request.Code)
        {
            AppRole? checkCode = await _roleService.GetByCode(request.Code);
            if (checkCode != null) throw new Exception("Bu kod daha önce kaydedilmiş!");
        }
        await _roleService.UpdateAsync(request);
        return new();
    }
}
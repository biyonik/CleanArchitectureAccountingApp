using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using MediatR;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

public sealed class DeleteRole
{
    public sealed class DeleteRoleRequest : IRequest<DeleteRoleResponse>
    {
        public Guid Id { get; set; }
    }

    public sealed class DeleteRoleResponse
    {
        public string Message { get; set; } = "Role silme işlemi başarılı";
    }
    
    public sealed class DeleteRoleHandler: IRequestHandler<DeleteRoleRequest, DeleteRoleResponse>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<DeleteRoleResponse> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole? role = await _roleService.GetById(request.Id.ToString());
            if (role == null) throw new Exception("Role bilgisi bulunamadı! Silme başarısız");
            await _roleService.DeleteAsync(request);
            return new();
        }
    }
}
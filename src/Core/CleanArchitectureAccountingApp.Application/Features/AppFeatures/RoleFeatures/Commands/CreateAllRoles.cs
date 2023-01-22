using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using CleanArchitectureAccountingApp.Domain.Roles;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;

public sealed class CreateAllRoles
{
    public sealed record Command : ICommand<Response>;

    public sealed record Response(
        string Message = "Roller başarıyla oluşturuldu"
    );
    
    public sealed class Handler: ICommandHandler<Command, Response>
    {
        private readonly IRoleService _roleService;

        public Handler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            IList<AppRole> originalRoleList = RoleList.GetStaticRoles();
            IList<AppRole> newRoleList = new List<AppRole>();

            foreach (var role in originalRoleList)
            {
                AppRole? checkRole = await _roleService.GetByCode(role.Code);
                if (checkRole == null) newRoleList.Add(role);
            }

            await _roleService.AddRangeAsync(newRoleList);
            return new();

        }
    }
}
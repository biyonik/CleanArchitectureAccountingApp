using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;

public class UpdateRole
{
    public sealed record Command(
        Guid Id,
        string Code,
        string Name
    ) : ICommand<Response>;

    public sealed record Response(
        string Message = "Rol güncelleme işlemi başarılı."
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
}
using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;

public class CreateRole
{
    public sealed record Command(
        string Code,
        string Name
    ) : ICommand<Response>;

    public sealed record Response(
        string Message = "Role kaydı başarılı!"
    );

    public sealed class Handler : ICommandHandler<Command, Response>
    {
        private readonly IRoleService _roleService;

        public Handler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            AppRole? role = await _roleService.GetByCode(request.Code);
            if (role != null) throw new Exception("Bu rol daha önce kaydedilmiş!");
            await _roleService.AddAsync(request);
            return new();
        }
    }
}
using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using FluentValidation;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;

public class CreateRole
{
    public sealed record Command(
        string Code,
        string Name
    ) : ICommand<Response>;

    public sealed class CreateRoleValidator : AbstractValidator<Command>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Rol kodu boş bırakılamaz!")
                .NotNull().WithMessage("Rol kodu boş bırakılamaz!");
            
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rol adı boş bırakılamaz!")
                .NotNull().WithMessage("Rol adı boş bırakılamaz!");
        }
    }

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
using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using FluentValidation;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;

public class UpdateRole
{
    public sealed record Command(
        Guid Id,
        string Code,
        string Name
    ) : ICommand<Response>;

    public sealed class UpdateRoleValidator : AbstractValidator<Command>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Rol Id değeri boş bırakılamaz!")
                .NotNull().WithMessage("Rol Id değeri boş bırakılamaz!");
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Rol kodu boş bırakılamaz!")
                .NotNull().WithMessage("Rol kodu boş bırakılamaz!");
            
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rol adı boş bırakılamaz!")
                .NotNull().WithMessage("Rol adı boş bırakılamaz!");
        }
    }

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
using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using FluentValidation;
using MediatR;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;

public sealed class DeleteRole
{
    public sealed class Command : ICommand<Response>
    {
        public Guid Id { get; set; }
    }

    public sealed class DeleteRoleValidator : AbstractValidator<Command>
    {
        public DeleteRoleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Rol Id değeri boş bırakılamaz!")
                .NotNull().WithMessage("Rol Id değeri boş bırakılamaz!");
        }
    }

    public sealed class Response
    {
        public string Message { get; set; } = "Role silme işlemi başarılı";
    }
    
    public sealed class DeleteRoleHandler: IRequestHandler<Command, Response>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            AppRole? role = await _roleService.GetById(request.Id.ToString());
            if (role == null) throw new Exception("Role bilgisi bulunamadı! Silme başarısız");
            await _roleService.DeleteAsync(request);
            return new();
        }
    }
}
using MediatR;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleRequest : IRequest<UpdateRoleResponse>
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
}
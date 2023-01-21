using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Queries;

public class GetAllRoles
{
    public sealed record Query : IQuery<Response>;

    public sealed record Response(
        IReadOnlyList<AppRole?> Roles
    );

    public sealed class Handler : IQueryHandler<Query, Response>
    {
        private readonly IRoleService _roleService;

        public Handler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
        {
            IReadOnlyList<AppRole?> roles = await _roleService.GetAllAsync();
            return new(roles);
        }
    }
}
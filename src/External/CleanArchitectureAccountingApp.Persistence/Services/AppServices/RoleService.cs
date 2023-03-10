using AutoMapper;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Persistence.Services.AppServices;

public sealed class RoleService : IRoleService
{
    private readonly RoleManager<AppRole> _roleManager;
    private readonly IMapper _mapper;

    public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task AddAsync(CreateRole.Command request)
    {
        AppRole? role = _mapper.Map<AppRole>(request);
        await _roleManager.CreateAsync(role);
    }

    public async Task AddRangeAsync(IEnumerable<AppRole> roles)
    {
        foreach (var role in roles)
        {
            await _roleManager.CreateAsync(role);
        }
    }

    public async Task UpdateAsync(UpdateRole.Command request)
    {
        AppRole? role = _mapper.Map<AppRole>(request);
        await _roleManager.UpdateAsync(role);
    }

    public async Task DeleteAsync(DeleteRole.Command request)
    {
        AppRole? role = _mapper.Map<AppRole>(request);
        await _roleManager.DeleteAsync(role);
    }

    public async Task<IReadOnlyList<AppRole?>> GetAllAsync()
    {
        IReadOnlyList<AppRole?> roles = await _roleManager.Roles.ToListAsync();
        return roles;
    }

    public async Task<AppRole?> GetById(string Id)
    {
        AppRole? role = await _roleManager.Roles.Where(x => x.Id.ToString() == Id).AsNoTracking().FirstOrDefaultAsync();
        return role;
    }

    public async Task<AppRole?> GetByCode(string Code)
    {
        AppRole? role = await _roleManager.Roles.Where(x => x.Code == Code).AsNoTracking().FirstOrDefaultAsync();
        return role;
    }
}
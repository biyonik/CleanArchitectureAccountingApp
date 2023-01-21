using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Queries.GetAllRoles;
using CleanArchitectureAccountingApp.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAccountingApp.Presentation.Controllers;

public class RolesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetAllRolesRequest request = new();
        GetAllRolesResponse response = await Mediator.Send(request);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(CreateRoleRequest request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateRoleRequest request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteRole.DeleteRoleRequest request)
    {
        var result = await Mediator.Send(new DeleteRole.DeleteRoleRequest { Id = request.Id });
        return Ok(result);
    }
}
using CleanArchitectureAccountingApp.Application.DTOs.Role;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Queries;
using CleanArchitectureAccountingApp.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAccountingApp.Presentation.Controllers;

public class RolesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await Mediator.Send(new GetAllRoles.Query());
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(RoleForAddDto request)
    {
        var result = await Mediator.Send(new CreateRole.Command(request.Code, request.Name));
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(RoleForUpdateDto request)
    {
        var result = await Mediator.Send(new UpdateRole.Command(request.Id, request.Code, request.Name));
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(RoleForDeleteDto request)
    {
        var result = await Mediator.Send(new DeleteRole.Command { Id = request.Id });
        return Ok(result);
    }
}
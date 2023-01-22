using CleanArchitectureAccountingApp.Application.Features.AppFeatures.AppUserFeatures.LoginFeatures.Commands;
using CleanArchitectureAccountingApp.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAccountingApp.Presentation.Controllers;

public class AuthController: BaseApiController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(Login.Command request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
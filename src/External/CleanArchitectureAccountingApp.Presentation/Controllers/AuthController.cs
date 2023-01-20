using CleanArchitectureAccountingApp.Application.Features.AppFeatures.AppUserFeatures.Login;
using CleanArchitectureAccountingApp.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAccountingApp.Presentation.Controllers;

public class AuthController: BaseApiController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}
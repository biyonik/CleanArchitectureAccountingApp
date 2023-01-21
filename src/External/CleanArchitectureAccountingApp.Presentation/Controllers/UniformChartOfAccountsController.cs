using CleanArchitectureAccountingApp.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Command.CreateUniformChartOfAccount;
using CleanArchitectureAccountingApp.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAccountingApp.Presentation.Controllers;

public sealed class UniformChartOfAccountsController: BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Add(CreateUniformChartOfAccountRequest request)
    {
        var response = await Mediator.Send(request);
        return Ok(response);
    }
}
using CleanArchitectureAccountingApp.Application.DTOs.CompaniesSubDTOs.UniformChartOfAccount;
using CleanArchitectureAccountingApp.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Command;
using CleanArchitectureAccountingApp.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAccountingApp.Presentation.Controllers;

public sealed class UniformChartOfAccountsController: BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Add(UniformChartOfAccountForAddDto request, CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(new CreateUniformChartOfAccount.Command(request.Code,
            request.Name,
            request.Type), cancellationToken);
        return Ok(response);
    }
}
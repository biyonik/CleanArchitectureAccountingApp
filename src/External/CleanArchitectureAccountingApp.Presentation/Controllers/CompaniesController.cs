using CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using CleanArchitectureAccountingApp.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAccountingApp.Presentation.Controllers;

public class CompaniesController: BaseApiController
{

    [HttpPost]
    public async Task<IActionResult> Add(CreateCompanyRequest request)
    {
        var response = await Mediator?.Send(request)!;
        return Ok(response);
    }
}
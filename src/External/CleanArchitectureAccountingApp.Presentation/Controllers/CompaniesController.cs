using CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabases;
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

    [HttpGet("[action]")]
    public async Task<IActionResult> MigrateCompanyDatabases()
    {
        var request = new MigrateCompanyDatabasesRequest();
        var response = await Mediator?.Send(request);
        return Ok(response);
    }
}
using CleanArchitectureAccountingApp.Application.DTOs.Company;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands;
using CleanArchitectureAccountingApp.Domain.AppEntities;
using CleanArchitectureAccountingApp.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAccountingApp.Presentation.Controllers;

public class CompaniesController: BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Add(CompanyForAddDto company, CancellationToken cancellationToken)
    {
        var request = new CreateCompany.Command(
            company.Name,
            company.ServerName,
            company.DatabaseName,
            company.PortNumber,
            company.UserId,
            company.Password
        );
        var response = await Mediator?.Send(request, cancellationToken)!;
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> MigrateCompanyDatabases(CancellationToken cancellationToken)
    {
        var response = await Mediator?.Send(new MigrateCompanyDatabase.Command(), cancellationToken);
        return Ok(response);
    }
}
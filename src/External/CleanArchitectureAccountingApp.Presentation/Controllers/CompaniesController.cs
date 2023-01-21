using CleanArchitectureAccountingApp.Application.DTOs.Company;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands;
using CleanArchitectureAccountingApp.Domain.AppEntities;
using CleanArchitectureAccountingApp.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureAccountingApp.Presentation.Controllers;

public class CompaniesController: BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Add(CompanyForAddDto company)
    {
        var request = new CreateCompany.Command(
            company.Name,
            company.ServerName,
            company.DatabaseName,
            company.PortNumber,
            company.UserId,
            company.Password
        );
        var response = await Mediator?.Send(request)!;
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> MigrateCompanyDatabases()
    {
        var response = await Mediator?.Send(new MigrateCompanyDatabase.Command());
        return Ok(response);
    }
}
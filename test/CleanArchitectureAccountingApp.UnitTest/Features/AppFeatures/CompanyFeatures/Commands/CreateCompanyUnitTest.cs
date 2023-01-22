using CleanArchitectureAccountingApp.Application.Services.AppServices.CompanyService;
using CleanArchitectureAccountingApp.Domain.AppEntities;
using Moq;
using Shouldly;

namespace CleanArchitectureAccountingApp.UnitTest.Features.AppFeatures.CompanyFeatures.Commands;

public sealed class CreateCompanyUnitTest
{
    private readonly Mock<ICompanyService> _companyService;

    public CreateCompanyUnitTest()
    {
        _companyService = new();
    }
    
    [Fact]
    public async Task CompanyShouldBeNull()
    {
        Company? company = await _companyService.Object.GetCompanyByName("Doe Company Inc");
        company.ShouldBeNull();
    }

    [Fact]
    public async Task CreateCompanyCommandResponseShouldNotBeNull()
    {
        var command = new Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany.Command(
            Name: "LTN Yazılım",
            ServerName: "127.0.0.11",
            DatabaseName: "ltnAppDb",
            PortNumber: "5433",
            UserId: "postgres",
            Password: "12345"
        );
        var handler =
            new Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany.Handler(_companyService.Object);
        Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany.Response response =
            await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
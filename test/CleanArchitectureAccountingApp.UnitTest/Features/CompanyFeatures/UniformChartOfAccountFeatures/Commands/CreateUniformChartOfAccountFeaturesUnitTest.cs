using AutoMapper;
using CleanArchitectureAccountingApp.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Command;
using CleanArchitectureAccountingApp.Application.Services.CompanyServices;
using CleanArchitectureAccountingApp.Domain.CompanyEntities;
using Moq;
using Shouldly;

namespace CleanArchitectureAccountingApp.UnitTest.Features.CompanyFeatures.UniformChartOfAccountFeatures.Commands;

public class CreateUniformChartOfAccountFeaturesUnitTest
{
    private readonly Mock<IUniformChartOfAccountService> _uniformChartOfAccountService;
    private readonly Mock<IMapper> _mapper;

    public CreateUniformChartOfAccountFeaturesUnitTest()
    {
        _uniformChartOfAccountService = new();
        _mapper = new();
    }

    [Fact]
    public async Task UniformChartOfAccountShouldBeNull()
    {
        UniformChartOfAccount? uniformChartOfAccount = await _uniformChartOfAccountService.Object.GetByCode("100.01.00");
        uniformChartOfAccount.ShouldBeNull();
    }

    [Fact]
    public async Task CreateUniformChartOfAccountCommandResponseShouldNotBeNull()
    {
        var command = new CreateUniformChartOfAccount.Command(
            Code: "100.01.00",
            Name: "Tl Kasa",
            Type: 'M'
        );

        var handler = new CreateUniformChartOfAccount.Handler(_uniformChartOfAccountService.Object, _mapper.Object);
        var response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeNullOrWhiteSpace();
    }
}
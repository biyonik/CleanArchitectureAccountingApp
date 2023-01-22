using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using Moq;
using Shouldly;

namespace CleanArchitectureAccountingApp.UnitTest.Features.AppFeatures.RoleFeatures.Commands;

public class UpdateRoleUnitTest
{
    private readonly Mock<IRoleService>? _roleService;

    public UpdateRoleUnitTest()
    {
        _roleService = new();
    }
    
    [Fact]
    public async Task AppRoleShouldNotBeNull()
    {
        _ = _roleService?.Setup(
            x => x.GetById(It.IsAny<Guid>().ToString())
        ).ReturnsAsync(new AppRole())!;
    }

    [Fact]
    public async Task AppRoleCodeShouldBeUnique()
    {
        AppRole checkRoleCode = await _roleService.Object.GetByCode("UniformChartOfAccount.Create");
        checkRoleCode.ShouldBeNull();
    }

    [Fact]
    public async Task UpdateRoleCommandResponseShouldNotBeNull()
    {
        var command = new UpdateRole.Command(
            Id: Guid.Parse("cc3ebe86-05db-47ab-a36e-3ab7779802a6"), 
            Code: "UnitTest.Create",
            Name: "Unit Test Kayıt Ekleme"
        );

        
        _ = _roleService?.Setup(
            x => x.GetById(command.Id.ToString())
        ).ReturnsAsync(new AppRole());
        
        
        var handler = new UpdateRole.Handler(_roleService.Object);
        var response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
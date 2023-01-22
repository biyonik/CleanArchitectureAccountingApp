using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using Moq;
using Shouldly;

namespace CleanArchitectureAccountingApp.UnitTest.Features.AppFeatures.RoleFeatures.Commands;

public sealed class CreateRoleUnitTest
{

    private readonly Mock<IRoleService>? _roleService;

    public CreateRoleUnitTest()
    {
        _roleService = new();
    }
    
    [Fact]
    public async Task AppRoleShouldBeNull()
    {
        AppRole? appRole = await _roleService?.Object.GetByCode("TestCode")!;
        appRole.ShouldBeNull();
    }

    [Fact]
    public async Task CreateRoleCommandResponseShouldNotBeNull()
    {
        var command = new CreateRole.Command(
            Code: "UnitTest.Create",
            Name: "Unit Test Kayıt Ekleme"
        );
        var handler = new CreateRole.Handler(_roleService.Object);
        var response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
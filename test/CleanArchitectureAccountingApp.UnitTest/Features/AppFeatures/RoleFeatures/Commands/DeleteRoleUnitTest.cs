using CleanArchitectureAccountingApp.Application.Features.AppFeatures.RoleFeatures.Commands;
using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using Moq;
using Shouldly;

namespace CleanArchitectureAccountingApp.UnitTest.Features.AppFeatures.RoleFeatures.Commands;

public class DeleteRoleUnitTest
{
    private readonly Mock<IRoleService>? _roleService;

    public DeleteRoleUnitTest()
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
    public async Task DeleteRoleCommandResponseShouldNotBeNull()
    {
        var command = new DeleteRole.Command()
        {
            Id = Guid.Parse("cc3ebe86-05db-47ab-a36e-3ab7779802a6")
        };
        
        _ = _roleService?.Setup(
            x => x.GetById(command.Id.ToString())
        ).ReturnsAsync(new AppRole());
        
        
        var handler = new DeleteRole.DeleteRoleHandler(_roleService.Object);
        var response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
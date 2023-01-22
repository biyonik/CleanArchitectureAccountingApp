using CleanArchitectureAccountingApp.Application.Services.AppServices.RoleService;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using Moq;

namespace CleanArchitectureAccountingApp.UnitTest.Features.AppFeatures.RoleFeatures.Queries;

public class GetAllRolesUnitTest
{
    private readonly Mock<IRoleService> _roleService;

    public GetAllRolesUnitTest()
    {
        _roleService = new();
    }

    [Fact]
    public async Task GetAllRolesShouldBeNotNull()
    {
        _roleService.Setup(
            x => x.GetAllAsync()).ReturnsAsync(new List<AppRole>());
    }
}
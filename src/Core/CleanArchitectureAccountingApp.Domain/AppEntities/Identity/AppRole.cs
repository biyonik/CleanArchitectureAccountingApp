using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

public sealed class AppRole: IdentityRole<Guid>
{
    public string Code { get; set; }
}
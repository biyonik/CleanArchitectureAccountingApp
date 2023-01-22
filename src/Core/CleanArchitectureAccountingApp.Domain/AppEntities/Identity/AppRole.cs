using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

public sealed class AppRole: IdentityRole<Guid>
{
    public string Code { get; set; }
    public string Title { get; set; }

    public AppRole()
    {
        
    }

    public AppRole(string Title, string Code, string Name)
    {
        Id = Guid.NewGuid();
        this.Name = Name;
        this.Title = Title;
        this.Code = Code;
    }
}
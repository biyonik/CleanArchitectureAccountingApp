using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitectureAccountingApp.Domain.Abstractions;

namespace CleanArchitectureAccountingApp.Domain.AppEntities;

public sealed class MainRole: Entity
{
    public string Title { get; set; }
    public bool IsRoleCreatedByAdmin { get; set; }
    
    [ForeignKey("Company")]
    public Guid? CompanyId { get; set; }
    public Company? Company { get; set; }
}
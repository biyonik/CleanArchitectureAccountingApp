using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitectureAccountingApp.Domain.Abstractions;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

namespace CleanArchitectureAccountingApp.Domain.AppEntities;

public sealed class MainRoleAndRoleRelationship: Entity
{
    [ForeignKey("AppRole")]
    public Guid RoleId { get; set; }
    public AppRole AppRole { get; set; }
    
    [ForeignKey("MainRole")]
    public Guid MainRoleId { get; set; }
    public MainRole MainRole { get; set; }
}
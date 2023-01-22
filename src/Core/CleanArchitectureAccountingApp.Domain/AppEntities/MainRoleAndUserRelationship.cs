using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitectureAccountingApp.Domain.Abstractions;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CleanArchitectureAccountingApp.Domain.AppEntities;

public sealed class MainRoleAndUserRelationship: Entity
{
    [ForeignKey("AppUser")]
    public Guid UserId { get; set; }
    public AppUser AppUser { get; set; }
    
    [ForeignKey("MainRole")]
    public Guid MainRoleId { get; set; }
    public MainRole MainRole { get; set; }
    
    [ForeignKey("Company")] 
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
}
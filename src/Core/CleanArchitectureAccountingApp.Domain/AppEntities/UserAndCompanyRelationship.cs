using System.ComponentModel.DataAnnotations.Schema;
using CleanArchitectureAccountingApp.Domain.Abstractions;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

namespace CleanArchitectureAccountingApp.Domain.AppEntities;

public sealed class UserAndCompanyRelationship: Entity
{
    [ForeignKey("AppUser")]
    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    
    [ForeignKey("Company")]
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
}
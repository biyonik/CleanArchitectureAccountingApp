using CleanArchitectureAccountingApp.Domain.Abstractions;

namespace CleanArchitectureAccountingApp.Domain.CompanyEntities;

public sealed class UniformChartOfAccount: Entity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public char Type { get; set; }
}
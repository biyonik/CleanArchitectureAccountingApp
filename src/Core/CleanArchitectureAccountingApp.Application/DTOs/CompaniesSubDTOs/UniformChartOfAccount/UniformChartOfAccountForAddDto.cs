namespace CleanArchitectureAccountingApp.Application.DTOs.CompaniesSubDTOs.UniformChartOfAccount;

public class UniformChartOfAccountForAddDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public char Type { get; set; }
    public Guid CompanyId { get; set; }
}
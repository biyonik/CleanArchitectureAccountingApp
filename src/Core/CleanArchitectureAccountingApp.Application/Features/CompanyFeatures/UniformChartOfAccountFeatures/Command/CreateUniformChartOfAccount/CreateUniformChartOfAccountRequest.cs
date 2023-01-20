using MediatR;

namespace CleanArchitectureAccountingApp.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Command.CreateUniformChartOfAccount;

public class CreateUniformChartOfAccountRequest: IRequest<CreateUniformChartOfAccountResponse>
{
    public string Code { get; set; }
    public string Name { get; set; }
    public char Type { get; set; }
    public Guid CompanyId { get; set; }
}
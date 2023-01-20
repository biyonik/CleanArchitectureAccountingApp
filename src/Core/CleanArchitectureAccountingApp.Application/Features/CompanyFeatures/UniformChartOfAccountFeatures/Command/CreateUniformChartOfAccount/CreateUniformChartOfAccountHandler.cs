using CleanArchitectureAccountingApp.Application.Services.CompanyServices;
using MediatR;

namespace CleanArchitectureAccountingApp.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Command.CreateUniformChartOfAccount;

public class CreateUniformChartOfAccountHandler: IRequestHandler<CreateUniformChartOfAccountRequest, CreateUniformChartOfAccountResponse>
{
    private readonly IUniformChartOfAccountService _uniformChartOfAccountService;

    public CreateUniformChartOfAccountHandler(IUniformChartOfAccountService uniformChartOfAccountService)
    {
        _uniformChartOfAccountService = uniformChartOfAccountService;
    }

    public async Task<CreateUniformChartOfAccountResponse> Handle(CreateUniformChartOfAccountRequest request, CancellationToken cancellationToken)
    {
        await _uniformChartOfAccountService.CreateUniformChartOfAccountAsync(request);
        return new();
    }
}
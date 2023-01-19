using CleanArchitectureAccountingApp.Application.Services.AppServices.CompanyService;
using CleanArchitectureAccountingApp.Domain.AppEntities;
using MediatR;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;

public sealed class CreateCompanyHandler: IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
{
    private readonly ICompanyService _companyService;

    public CreateCompanyHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        Company? company = await _companyService.GetCompanyByName(request.Name);
        if (company != null) throw new Exception("Bu şirket adı daha önce kullanılmış");
        
        await _companyService.Create(request);
        return new();
    }
}
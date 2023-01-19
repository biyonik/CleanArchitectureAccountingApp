using AutoMapper;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using CleanArchitectureAccountingApp.Application.Services.AppServices.CompanyService;
using CleanArchitectureAccountingApp.Domain.AppEntities;
using CleanArchitectureAccountingApp.Persistence.Context;

namespace CleanArchitectureAccountingApp.Persistence.Services.AppServices;

public sealed class CompanyService: ICompanyService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CompanyService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Create(CreateCompanyRequest request)
    {
        var company = _mapper.Map<Company>(request);
        await _context.Set<Company>().AddAsync(company);
        var result = await _context.SaveChangesAsync() > 0;
        return result;
    }
}
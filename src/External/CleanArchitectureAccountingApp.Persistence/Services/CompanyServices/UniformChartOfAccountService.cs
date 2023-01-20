using AutoMapper;
using CleanArchitectureAccountingApp.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Command.CreateUniformChartOfAccount;
using CleanArchitectureAccountingApp.Application.Services.CompanyServices;
using CleanArchitectureAccountingApp.Domain;
using CleanArchitectureAccountingApp.Domain.CompanyEntities;
using CleanArchitectureAccountingApp.Domain.Repositories.UniformChartOfAccountRepositories;
using CleanArchitectureAccountingApp.Persistence.Context;

namespace CleanArchitectureAccountingApp.Persistence.Services.CompanyServices;

public sealed class UniformChartOfAccountService: IUniformChartOfAccountService
{
    private readonly IUniformChartOfAccountCommandRepository _uniformChartOfAccountCommandRepository;
    private readonly IContextService _contextService;
    private CompanyDbContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UniformChartOfAccountService(IUniformChartOfAccountCommandRepository uniformChartOfAccountCommandRepository, IContextService contextService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uniformChartOfAccountCommandRepository = uniformChartOfAccountCommandRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> CreateUniformChartOfAccountAsync(CreateUniformChartOfAccountRequest request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _uniformChartOfAccountCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        var mappedEntity = _mapper.Map<UniformChartOfAccount>(request);
        await _uniformChartOfAccountCommandRepository.AddAsync(mappedEntity);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}
using AutoMapper;
using CleanArchitectureAccountingApp.Application.DTOs.CompaniesSubDTOs.UniformChartOfAccount;
using CleanArchitectureAccountingApp.Application.Services.CompanyServices;
using CleanArchitectureAccountingApp.Domain;
using CleanArchitectureAccountingApp.Domain.CompanyEntities;
using CleanArchitectureAccountingApp.Domain.Repositories.UniformChartOfAccountRepositories;
using CleanArchitectureAccountingApp.Persistence.Context;

namespace CleanArchitectureAccountingApp.Persistence.Services.CompanyServices;

public sealed class UniformChartOfAccountService: IUniformChartOfAccountService
{
    private readonly IUniformChartOfAccountCommandRepository _uniformChartOfAccountCommandRepository;
    private readonly IUniformChartOfAccountQueryRepository _uniformChartOfAccountQueryRepository;
    private readonly IContextService _contextService;
    private CompanyDbContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UniformChartOfAccountService(IUniformChartOfAccountCommandRepository uniformChartOfAccountCommandRepository, IContextService contextService, IUnitOfWork unitOfWork, IMapper mapper, IUniformChartOfAccountQueryRepository uniformChartOfAccountQueryRepository)
    {
        _uniformChartOfAccountCommandRepository = uniformChartOfAccountCommandRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _uniformChartOfAccountQueryRepository = uniformChartOfAccountQueryRepository;
    }

    public async Task<bool> CreateUniformChartOfAccountAsync(UniformChartOfAccountForAddDto request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _uniformChartOfAccountCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        var mappedEntity = _mapper.Map<UniformChartOfAccount>(request);
        await _uniformChartOfAccountCommandRepository.AddAsync(mappedEntity, cancellationToken);
        return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<UniformChartOfAccount?> GetByCode(string code)
    {
        return await _uniformChartOfAccountQueryRepository.GetAsync(x => x.Code == code);
    }
}
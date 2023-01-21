using AutoMapper;
using CleanArchitectureAccountingApp.Application.DTOs.CompaniesSubDTOs.UniformChartOfAccount;
using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.CompanyServices;

namespace CleanArchitectureAccountingApp.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Command;

public class CreateUniformChartOfAccount
{
    public sealed record Command(
        string Code,
        string Name,
        char Type
    ) : ICommand<Response>;

    public sealed record Response(
        string Message = "Hesap planı kaydı başarıyla tamamlandı!"
    );

    public sealed class Handler : ICommandHandler<Command, Response>
    {
        private readonly IUniformChartOfAccountService _uniformChartOfAccountService;
        private readonly IMapper _mapper;

        public Handler(IUniformChartOfAccountService uniformChartOfAccountService, IMapper mapper)
        {
            _uniformChartOfAccountService = uniformChartOfAccountService;
            _mapper = mapper;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            var mappedEntity = _mapper.Map<UniformChartOfAccountForAddDto>(request);
            await _uniformChartOfAccountService.CreateUniformChartOfAccountAsync(mappedEntity);
            return new();
        }
    }
}
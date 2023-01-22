using AutoMapper;
using CleanArchitectureAccountingApp.Application.DTOs.CompaniesSubDTOs.UniformChartOfAccount;
using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.CompanyServices;
using CleanArchitectureAccountingApp.Domain.CompanyEntities;
using FluentValidation;

namespace CleanArchitectureAccountingApp.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Command;

public class CreateUniformChartOfAccount
{
    public sealed record Command(
        string Code,
        string Name,
        char Type
    ) : ICommand<Response>;

    public sealed class CreateUniformChartOfAccountValidator : AbstractValidator<Command>
    {
        public CreateUniformChartOfAccountValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Hesap planı kodu boş bırakılamaz!")
                .NotNull().WithMessage("Hesap planı kodu boş bırakılamaz!");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Hesap planı adı boş bırakılamaz!")
                .NotNull().WithMessage("Hesap planı adı boş bırakılamaz!");
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Hesap planı tipi boş bırakılamaz!")
                .NotNull().WithMessage("Hesap planı tipi boş bırakılamaz!");
        }
    }

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
            UniformChartOfAccount? uniformChartOfAccount = await _uniformChartOfAccountService.GetByCode(request.Code);
            if (uniformChartOfAccount != null) throw new Exception("Bu hesap planı kodu daha önce tanımlanmış!");
            
            var mappedEntity = _mapper.Map<UniformChartOfAccountForAddDto>(request);
            await _uniformChartOfAccountService.CreateUniformChartOfAccountAsync(mappedEntity, cancellationToken);
            return new();
        }
    }
}
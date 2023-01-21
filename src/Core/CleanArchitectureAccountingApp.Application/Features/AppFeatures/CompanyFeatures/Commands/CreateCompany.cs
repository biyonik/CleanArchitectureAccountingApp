using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.AppServices.CompanyService;
using CleanArchitectureAccountingApp.Domain.AppEntities;
using FluentValidation;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands;

public class CreateCompany
{
    public sealed record Command(
        string Name,
        string ServerName,
        string DatabaseName,
        string PortNumber,
        string UserId,
        string Password
    ) : ICommand<Response>;

    public sealed class CreateCompanyValidator : AbstractValidator<Command>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Şirket adı boş bırakılamaz!");
            RuleFor(x => x.Name).NotNull().WithMessage("Şirket adı boş bırakılamaz!");
            RuleFor(x => x.DatabaseName).NotNull().WithMessage("Veritabanı adı boş bırakılamaz!");
            RuleFor(x => x.DatabaseName).NotEmpty().WithMessage("Veritabanı adı boş bırakılamaz!");
            RuleFor(x => x.ServerName).NotEmpty().WithMessage("Sunucu adı boş bırakılamaz!");
            RuleFor(x => x.ServerName).NotNull().WithMessage("Sunucu adı boş bırakılamaz!");
            RuleFor(x => x.PortNumber).NotEmpty().WithMessage("Port numarası boş bırakılamaz!");
            RuleFor(x => x.PortNumber).NotNull().WithMessage("Port numarası boş bırakılamaz!");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz!");
            RuleFor(x => x.UserId).NotNull().WithMessage("Kullanıcı adı boş bırakılamaz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş bırakılamaz!");
            RuleFor(x => x.Password).NotNull().WithMessage("Parola boş bırakılamaz!");
        }
    }

    public sealed record Response(
        string Message = "Şirket kaydı ekleme başarıyla tamamlandı."
    );

    public sealed class Handler : ICommandHandler<Command, Response>
    {
        private readonly ICompanyService _companyService;

        public Handler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            Company? company = await _companyService.GetCompanyByName(request.Name);
            if (company != null) throw new Exception("Bu şirket adı daha önce kullanılmış");

            await _companyService.Create(request, cancellationToken);
            return new();
        }
    }
}
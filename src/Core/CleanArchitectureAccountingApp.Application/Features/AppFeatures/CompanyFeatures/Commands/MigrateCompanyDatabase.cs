using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.AppServices.CompanyService;

namespace CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands;

public class MigrateCompanyDatabase
{
    public sealed record Command : ICommand<Response>;

    public sealed record Response(
        string Message = "Şirketlerin databse bilgileri güncellendi."    
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
            await _companyService.MigrateCompanyDatabases();
            return new();
        }
    }
}
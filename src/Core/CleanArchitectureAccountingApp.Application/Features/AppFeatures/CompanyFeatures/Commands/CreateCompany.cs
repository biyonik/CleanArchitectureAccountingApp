﻿using CleanArchitectureAccountingApp.Application.Messaging;
using CleanArchitectureAccountingApp.Application.Services.AppServices.CompanyService;
using CleanArchitectureAccountingApp.Domain.AppEntities;

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
        
            await _companyService.Create(request);
            return new();
        }
    }
}
﻿using CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands;
using CleanArchitectureAccountingApp.Domain.AppEntities;

namespace CleanArchitectureAccountingApp.Application.Services.AppServices.CompanyService;

public interface ICompanyService
{
    Task<bool> Create(CreateCompany.Command request);
    Task<Company?> GetCompanyByName(string name);
    Task<bool> MigrateCompanyDatabases();
}
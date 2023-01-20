﻿using CleanArchitectureAccountingApp.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Command.CreateUniformChartOfAccount;

namespace CleanArchitectureAccountingApp.Application.Services.CompanyServices;

public interface IUniformChartOfAccountService
{
    Task<bool> CreateUniformChartOfAccountAsync(CreateUniformChartOfAccountRequest request);
}
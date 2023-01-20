using AutoMapper;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using CleanArchitectureAccountingApp.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Command.CreateUniformChartOfAccount;
using CleanArchitectureAccountingApp.Domain.AppEntities;
using CleanArchitectureAccountingApp.Domain.CompanyEntities;

namespace CleanArchitectureAccountingApp.Persistence.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCompanyRequest, Company>().ReverseMap();
        CreateMap<CreateUniformChartOfAccountRequest, UniformChartOfAccount>().ReverseMap();
    }
}
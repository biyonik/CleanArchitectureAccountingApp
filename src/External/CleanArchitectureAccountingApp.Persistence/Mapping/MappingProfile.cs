using AutoMapper;
using CleanArchitectureAccountingApp.Application.DTOs.CompaniesSubDTOs.UniformChartOfAccount;
using CleanArchitectureAccountingApp.Application.DTOs.Company;
using CleanArchitectureAccountingApp.Application.DTOs.Role;
using CleanArchitectureAccountingApp.Application.Features.CompanyFeatures.UniformChartOfAccountFeatures.Command;
using CleanArchitectureAccountingApp.Domain.AppEntities;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using CleanArchitectureAccountingApp.Domain.CompanyEntities;

namespace CleanArchitectureAccountingApp.Persistence.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<CompanyForAddDto, Company>().ReverseMap();
        CreateMap<UniformChartOfAccountForAddDto, UniformChartOfAccount>().ReverseMap();
        CreateMap<UniformChartOfAccountForAddDto, CreateUniformChartOfAccount.Command>().ReverseMap();
        CreateMap<RoleForAddDto, AppRole>().ReverseMap();
        CreateMap<RoleForUpdateDto, AppRole>().ReverseMap();
        CreateMap<RoleForDeleteDto, AppRole>().ReverseMap();
    }
}
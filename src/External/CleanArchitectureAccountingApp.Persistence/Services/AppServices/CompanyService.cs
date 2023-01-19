﻿using AutoMapper;
using CleanArchitectureAccountingApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using CleanArchitectureAccountingApp.Application.Services.AppServices.CompanyService;
using CleanArchitectureAccountingApp.Domain.AppEntities;
using CleanArchitectureAccountingApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Persistence.Services.AppServices;

public sealed class CompanyService: ICompanyService
{
    private static readonly Func<AppDbContext, string, Task<Company?>> GetCompanyByNameCompiled
        = EF.CompileAsyncQuery((AppDbContext ctx, string name) =>
            ctx.Set<Company>().FirstOrDefault(x => x.Name == name));
    
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CompanyService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Create(CreateCompanyRequest request)
    {
        var company = _mapper.Map<Company>(request);
        await _context.Set<Company>().AddAsync(company);
        var result = await _context.SaveChangesAsync() > 0;
        return result;
    }

    public async Task<Company?> GetCompanyByName(string name)
    {
        return await GetCompanyByNameCompiled(_context, name);
    }

    public async Task<bool> MigrateCompanyDatabases()
    {
        var companies = await _context.Set<Company>().ToListAsync();
        if (companies.Count == 0) return false;
        foreach (var company in companies)
        {
            var db = new CompanyDbContext(company);
            await db.Database.MigrateAsync();
        }

        return true;
    }
}
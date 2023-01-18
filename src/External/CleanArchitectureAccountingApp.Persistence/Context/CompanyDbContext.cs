using CleanArchitectureAccountingApp.Domain.AppEntities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureAccountingApp.Persistence.Context;

public sealed class CompanyDbContext : DbContext
{
    private string ConnectionString = "";
    private readonly AppDbContext _appDbContext;

    public CompanyDbContext(Guid companyId, AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        Company company = _appDbContext.Companies.Find(companyId);
        
        ConnectionString = string.IsNullOrWhiteSpace(company?.UserId) 
            ? $@"Server={company.ServerName};Port={company.PortNumber};Database={company.DatabaseName};User Id=postgres;Password=12345;" 
            : $@"Server={company.ServerName};Port={company.PortNumber};Database={company.DatabaseName};User Id={company.UserId};Password={company.Password};";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }
}
using CleanArchitectureAccountingApp.Domain.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArchitectureAccountingApp.Persistence.Context;

public sealed class CompanyDbContext : DbContext
{
    private string ConnectionString = "";

    public CompanyDbContext(Company? company = null)
    {
        if (company != null)
        {
            ConnectionString = string.IsNullOrWhiteSpace(company?.UserId) 
                ? $@"Server={company?.ServerName};Port={company?.PortNumber};Database={company?.DatabaseName};User Id=postgres;Password=12345;" 
                : $@"Server={company.ServerName};Port={company.PortNumber};Database={company.DatabaseName};User Id={company.UserId};Password={company.Password};";
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

    public class CompanyDbContextFactor : IDesignTimeDbContextFactory<CompanyDbContext>
    {
        public CompanyDbContext CreateDbContext(string[] args)
        {
            return new CompanyDbContext();
        }
    }
}
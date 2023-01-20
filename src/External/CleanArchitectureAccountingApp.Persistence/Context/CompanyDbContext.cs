using CleanArchitectureAccountingApp.Domain.Abstractions;
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
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker.Entries<Entity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(p => p.Id).CurrentValue = Guid.NewGuid();
                entry.Property(p => p.CreatedDate).CurrentValue = DateTime.Now;
            }else if (entry.State == EntityState.Modified)
            {
                entry.Property(p => p.UpdatedDate).CurrentValue = DateTime.Now;
            }else if (entry.State == EntityState.Deleted)
            {
                entry.Property(p => p.RemovedDate).CurrentValue = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
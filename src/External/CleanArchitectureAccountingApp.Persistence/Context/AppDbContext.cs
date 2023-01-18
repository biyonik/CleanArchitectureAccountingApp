using CleanArchitectureAccountingApp.Domain.AppEntities;
using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureAccountingApp.Persistence.Context;

/// <summary>
/// Master Context
/// </summary>
public sealed class AppDbContext: IdentityDbContext<AppUser, AppRole, Guid>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{envName}.json", optional: false)
            .Build();
        optionsBuilder.UseNpgsql(configurationRoot.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<UserAndCompanyRelationship> UserAndCompanyRelationships { get; set; }
}
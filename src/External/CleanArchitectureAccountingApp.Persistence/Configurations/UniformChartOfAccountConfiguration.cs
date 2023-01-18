using CleanArchitectureAccountingApp.Domain.CompanyEntities;
using CleanArchitectureAccountingApp.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureAccountingApp.Persistence.Configurations;

public sealed class UniformChartOfAccountConfiguration: IEntityTypeConfiguration<UniformChartOfAccount>
{
    public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
    {
        builder.ToTable(TableNames.UniformChartOfAccount);
        builder.HasKey(x => x.Id);
    }
}
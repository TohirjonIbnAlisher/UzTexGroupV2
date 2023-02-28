using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable(nameof(Company))
            .HasKey(company => new{ company.Id, company.LanguageCode });

        builder.Property(company => company.Name)
            .IsRequired()
            .HasMaxLength(100);
    }  
}

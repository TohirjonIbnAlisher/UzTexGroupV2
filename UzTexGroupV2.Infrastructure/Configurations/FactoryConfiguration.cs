using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
{
    public void Configure(EntityTypeBuilder<Factory> builder)
    {
        builder.ToTable(nameof(Factory))
            .HasKey(factory => new { factory.Id, factory.LanguageCode });

        builder
            .HasOne(factory => factory.Company)
            .WithMany(company => company.Factories)
            .HasForeignKey(factory => new { factory.CompanyId, factory.LanguageCode });

        builder
            .HasOne(factory => factory.Address)
            .WithOne()
            .HasForeignKey<Factory>(factory => factory.AddressId);
    }
}
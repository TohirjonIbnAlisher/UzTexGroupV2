using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address));

        builder.HasKey(add => add.Id);

        builder
            .Property(add => add.Country)
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .Property(add => add.Region)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(add => add.District)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(add => add.Street)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(add => add.PostalCode)
            .IsRequired();
    }
}

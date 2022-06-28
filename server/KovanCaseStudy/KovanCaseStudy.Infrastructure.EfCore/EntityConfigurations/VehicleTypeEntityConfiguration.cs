using KovanCaseStudy.Domain.Aggregates.VehiclesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KovanCaseStudy.Infrastructure.EfCore.EntityConfigurations;

public class VehicleTypeEntityConfiguration : IEntityTypeConfiguration<VehicleType>
{
    public void Configure(EntityTypeBuilder<VehicleType> builder)
    {
        builder.ToTable("VehicleType");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .IsRequired();

        builder.Property(o => o.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasData(VehicleType.List());
    }
}
using KovanCaseStudy.Domain.Aggregates.UserAggregate;
using KovanCaseStudy.Domain.Aggregates.VehiclesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KovanCaseStudy.Infrastructure.EfCore.EntityConfigurations;

public class VehicleEntityConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicle");

        builder.HasKey(b => b.Id); //PK
        
        builder.Property(b => b.VehicleTypeId);
        builder.HasOne(p => p.VehicleType).WithMany().HasForeignKey(fk => fk.VehicleTypeId);

        builder.HasData(new Vehicle("OS7VA", VehicleType.Bike.Id, true, true, 8, 39.9244125486328m, 32.8643810105882m));
        builder.HasData(new Vehicle("Q2RLQ", VehicleType.Scooter.Id, false, false, 5, 39.9244125486328m,
            32.8643810105882m));
        builder.HasData(new Vehicle("Z2LBF", VehicleType.Scooter.Id, false, false, 5, 39.9244125486328m,
            32.8643810105882m));
        builder.HasData(
            new Vehicle("INZPG", VehicleType.Bike.Id, false, false, 5, 39.9244125486328m, 32.8643810105882m));
        builder.HasData(
            new Vehicle("FBGXO", VehicleType.Bike.Id, false, false, 5, 39.9244125486328m, 32.8643810105882m));
        builder.HasData(
            new Vehicle("LT3RT", VehicleType.Bike.Id, false, false, 5, 39.9244125486328m, 32.8643810105882m));
        builder.HasData(new Vehicle("T2ZX9", VehicleType.Scooter.Id, false, false, 5, 39.9244125486328m,
            32.8643810105882m));
        builder.HasData(new Vehicle("2NP1R", VehicleType.Bike.Id, false, false, 5,
            39.9244125486328m, 32.8643810105882m));
        builder.HasData(new Vehicle("WZKOU", VehicleType.Bike.Id, false, false, 5,
            39.9244125486328m, 32.8643810105882m));
        builder.HasData(new Vehicle("FV2FO", VehicleType.Scooter.Id, false, false, 5, 39.9244125486328m,
            32.8643810105882m));
    }
}
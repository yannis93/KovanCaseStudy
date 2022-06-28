using KovanCaseStudy.SharedKernel.SeedWork;

namespace KovanCaseStudy.Domain.Aggregates.VehiclesAggregate;

public class VehicleType : Enumeration, IEntity
{
    public static readonly VehicleType Bike = new VehicleType(1, "Bike");
    public static readonly VehicleType Scooter = new VehicleType(2, "Scooter");

    public VehicleType(int id, string name) : base(id, name)
    {
    }

    public static IEnumerable<VehicleType> List() =>
        new[]
        {
            Bike,
            Scooter
        };
}
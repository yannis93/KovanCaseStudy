using KovanCaseStudy.Domain.Aggregates.VehiclesAggregate;

namespace KovanCaseStudy.Infrastructure.EfCore.Repositories;

public class VehicleRepository: EFRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(KovanDbContext context) : base(context)
    { }
}
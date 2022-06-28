using KovanCaseStudy.Domain.Aggregates.UserAggregate;
using KovanCaseStudy.Domain.Aggregates.VehiclesAggregate;
using KovanCaseStudy.Infrastructure.EfCore.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace KovanCaseStudy.Infrastructure.EfCore;

public class KovanDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
    public DbSet<User> Users { get; set; }

    public KovanDbContext(DbContextOptions<KovanDbContext> options) : base(options)
    {
    }

    public KovanDbContext(DbContextOptions<KovanDbContext> options, IMediator mediator) : base(options)
    {
        System.Diagnostics.Debug.WriteLine("KovanDbContext::ctor ->" + this.GetHashCode());
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

         builder.ApplyConfiguration(new UserEntityConfigurations());
         builder.ApplyConfiguration(new VehicleEntityConfiguration());
         builder.ApplyConfiguration(new VehicleTypeEntityConfiguration());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        await base.SaveChangesAsync(cancellationToken);
        
        return true;
    }

    /// <summary>
    /// WARNING! 
    /// This method can save all changes without raising any events!
    /// Use it just in transaction scope or non-domain process!
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
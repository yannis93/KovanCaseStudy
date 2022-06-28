using KovanCaseStudy.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KovanCaseStudy.Infrastructure.EfCore;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureEFCore(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<KovanDbContext>(options => {
            options.EnableSensitiveDataLogging();
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }, ServiceLifetime.Singleton);

        return services;
    }
}
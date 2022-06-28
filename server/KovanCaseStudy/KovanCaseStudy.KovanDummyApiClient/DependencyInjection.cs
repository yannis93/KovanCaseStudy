using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KovanCaseStudy.KovanDummyApiClient;

public static class DependencyInjection
{
    public static IServiceCollection AddKovanDummyApiClient(this IServiceCollection services,
        IConfiguration configuration)
    {
    services.Configure<KovanDummyApiOptions>(options =>
        configuration.GetSection("KovanDummyApiOptions").Bind(options));
    
    var kovanDummyApiOptions = new KovanDummyApiOptions();
    configuration.Bind(nameof(kovanDummyApiOptions), kovanDummyApiOptions);
    services.AddHttpClient("KovanDummyApi", c =>
    {
        c.BaseAddress = new Uri(kovanDummyApiOptions.BaseAddress);
        c.DefaultRequestHeaders.Add("Accept", "application/json");
    });
    
    services.AddScoped<IClient, Client>();
    
    return services;
    }
}
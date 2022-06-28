using KovanCaseStudy.Domain.Aggregates.VehiclesAggregate;
using KovanCaseStudy.KovanDummyApiClient;
using KovanCaseStudy.KovanDummyApiClient.Models.Responses.Items;

namespace KovanCaseStudy.Api.GraphQLCore;


public class Query
{
    private readonly IClient _client;

    public Query(IClient client)
    {
        _client = client;
    }

    public async Task<ItemsResponse> GetVehicle(string? page = null, string? bikeId = null, string? vehicleType = null)
    {
        return await _client.ItemsAsync(page, bikeId, vehicleType);
    }
}
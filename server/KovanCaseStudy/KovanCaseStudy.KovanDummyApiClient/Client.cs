using System.Diagnostics.Contracts;
using System.Text;
using System.Text.Json;
using KovanCaseStudy.KovanDummyApiClient.Models.Responses.Items;

namespace KovanCaseStudy.KovanDummyApiClient;

public class Client : IClient
{
    private readonly IHttpClientFactory _clientFactory;

    public Client(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }


    public async Task<ItemsResponse> ItemsAsync(string page=null, string bikeId = null, string vehicleType=null)
    {
        var queryParams = new Dictionary<string, object>()
        {
            {"page", page},
            {"bike_id", bikeId},
            {"vehicle_type", vehicleType}
        };
        var itemsResponse = await MakeGetRequest<ItemsResponse>("items", queryParams);
        if (itemsResponse==null)
        {
            return null;
        }
        itemsResponse.Data.Bikes.RemoveAll(x => x == null);
        return itemsResponse;
    }

    private async Task<TResponse> MakeGetRequest<TResponse>(string url, Dictionary<string, object> queryStrings)
    {
        var client = _clientFactory.CreateClient("KovanDummyApi");
        UriBuilder builder = new UriBuilder(client.BaseAddress + url);
        foreach (var item in queryStrings)
        {
            if (item.Value != null)
            {
                builder.Query = builder.Query + $"{item.Key}={item.Value}&";
            }
        }
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = builder.Uri,
        };
        using (var response = await client.SendAsync(request))
        {
            var body = await response.Content.ReadAsStringAsync();
            TResponse data = default(TResponse);
            try
            {
                data = JsonSerializer.Deserialize<TResponse>(body,
                    new JsonSerializerOptions()
                        { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault });
            }
            catch (Exception e)
            {
            }

            return data;
        }
    }
}
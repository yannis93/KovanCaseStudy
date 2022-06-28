using KovanCaseStudy.KovanDummyApiClient.Models.Responses.Items;

namespace KovanCaseStudy.KovanDummyApiClient;

public interface IClient
{
    Task<ItemsResponse> ItemsAsync(string page=null, string bikeId=null, string vehicleType=null);

}
using System.ComponentModel;
using System.Text.Json.Serialization;
using KovanCaseStudy.KovanDummyApiClient.SeedWork.JsonConverter;

namespace KovanCaseStudy.KovanDummyApiClient.Models.Responses.Items;

public class ItemsResponse
{
    [JsonPropertyName("last_updated")]
    public long LastUpdated { get; set; }

    [JsonPropertyName("ttl")]
    public int Ttl { get; set; }

    [JsonPropertyName("data")]
    public Data Data { get; set; }

    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }

    [JsonPropertyName("nextPage")]
    public bool NextPage { get; set; }
}

public class Bike
{
    [JsonPropertyName("bike_id")]
    public string? BikeId { get; set; }

    [JsonPropertyName("lat")]
    public double? Lat { get; set; }

    [JsonPropertyName("lon")]
    public double? Lon { get; set; }
    [JsonPropertyName("is_reserved")]
    [JsonConverter(typeof(BoolConverter))]
    public bool? IsReserved { get; set; }

    [JsonPropertyName("is_disabled")]
    [JsonConverter(typeof(BoolConverter))]
    public bool? IsDisabled { get; set; }

    [JsonPropertyName("vehicle_type")]
    public string? VehicleType { get; set; }

    [JsonPropertyName("total_bookings")]
    [JsonConverter(typeof(IntegerConverter))]
    public int? TotalBookings { get; set; }

    [JsonPropertyName("android")]
    public string? Android { get; set; }

    [JsonPropertyName("ios")]
    public string? Ios { get; set; }
}

public class Data
{
    [JsonPropertyName("bikes")]
    public List<Bike?> Bikes  { get; set; }
}

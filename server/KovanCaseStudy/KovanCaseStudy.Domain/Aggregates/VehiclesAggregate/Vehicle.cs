namespace KovanCaseStudy.Domain.Aggregates.VehiclesAggregate;

public class Vehicle
{
    public Vehicle(string id, int vehicleTypeId, bool isReserved, bool isDisabled, int totalBooking, decimal lat, decimal lon)
    {
        Id = id;
        VehicleTypeId = vehicleTypeId;
        IsReserved = isReserved;
        IsDisabled = isDisabled;
        TotalBooking = totalBooking;
        Lat = lat;
        Lon = lon;
    }

    public string Id { get; set; }
    public int VehicleTypeId { get; private set; }
    public VehicleType VehicleType { get; private set; }
    public bool IsReserved { get; private set; }
    public bool IsDisabled { get; private set; }
    public int TotalBooking { get; private set; }
    public decimal Lat { get; private set; }
    public decimal Lon { get; private set; }
}
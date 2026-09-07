namespace SmartDeliverySystem;

public static class ShipmentExtensions
{
    public static string GetSummary(this Shipment shipment)
    {
        return shipment.TrackingCode + " | " + shipment.ShipmentType + " | "
            + shipment.Weight + " KG | " + shipment.GetTrackingStatus();
    }

    public static bool IsDelivered(this Shipment shipment)
    {
        return shipment.GetTrackingStatus() == "Delivered";
    }
}

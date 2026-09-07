namespace SmartDeliverySystem;

public partial class Shipment
{
    partial void OnTrackingStatusChanged(string newStatus)
    {
        Console.WriteLine("Tracking status changed to: " + newStatus);
    }
}

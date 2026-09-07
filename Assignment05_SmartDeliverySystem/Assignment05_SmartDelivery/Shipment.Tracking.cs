namespace SmartDeliverySystem;

public partial class Shipment
{
    private string trackingStatus = "In Transit";

    public string GetTrackingStatus()
    {
        return trackingStatus;
    }

    public void UpdateTrackingStatus(string newStatus)
    {
        if (!string.IsNullOrWhiteSpace(newStatus))
        {
            trackingStatus = newStatus;
            OnTrackingStatusChanged(newStatus);
        }
    }

    partial void OnTrackingStatusChanged(string newStatus);
}

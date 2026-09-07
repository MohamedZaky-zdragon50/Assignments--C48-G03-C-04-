namespace SmartDeliverySystem;

public class StandardShipment : Shipment
{
    public override string ShipmentType
    {
        get { return "Standard"; }
    }

    public StandardShipment(string trackingCode, string description, decimal weight,
        decimal deliveryFee, DeliveryAddress destination)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
    }
}

namespace SmartDeliverySystem;

public class InternationalShipment : Shipment
{
    private string destinationCountry;
    private decimal customsFee;

    public string DestinationCountry
    {
        get { return destinationCountry; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                destinationCountry = value;
        }
    }

    public decimal CustomsFee
    {
        get { return customsFee; }
        set
        {
            if (value >= 0)
                customsFee = value;
        }
    }

    public override string ShipmentType
    {
        get { return "International"; }
    }

    public override decimal EstimatedCost
    {
        get { return base.EstimatedCost + CustomsFee; }
    }

    public InternationalShipment(string trackingCode, string description, decimal weight,
        decimal deliveryFee, DeliveryAddress destination, string destinationCountry,
        decimal customsFee)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
        DestinationCountry = string.IsNullOrWhiteSpace(destinationCountry) ? "Unknown" : destinationCountry;
        CustomsFee = customsFee >= 0 ? customsFee : 0;
    }
}

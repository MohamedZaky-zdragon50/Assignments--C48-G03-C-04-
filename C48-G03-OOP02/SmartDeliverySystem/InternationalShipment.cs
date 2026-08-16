namespace SmartDeliverySystem;

public class InternationalShipment : Shipment
{
    public string DestinationCountry { get; set; }
    public decimal CustomsFee { get; set; }

    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5) + CustomsFee;
        }
    }

    public InternationalShipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination,
        string destinationCountry,
        decimal customsFee)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
        if (string.IsNullOrWhiteSpace(destinationCountry))
            throw new ArgumentException("Destination country cannot be empty.");

        if (customsFee < 0)
            throw new ArgumentException("Customs fee cannot be negative.");

        DestinationCountry = destinationCountry;
        CustomsFee = customsFee;
    }

    public override void PrintShipment()
    {
        base.PrintShipment();
        Console.WriteLine($"Country: {DestinationCountry}");
        Console.WriteLine($"Customs Fee: {CustomsFee:F2}");
        Console.WriteLine($"Final Cost: {EstimatedCost:F2}");
    }
}

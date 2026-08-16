namespace SmartDeliverySystem;

public class ExpressShipment : Shipment
{
    public decimal ExtraFee { get; set; }

    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5) + ExtraFee;
        }
    }

    public ExpressShipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination,
        decimal extraFee)
        : base(trackingCode, description, weight, deliveryFee, destination)
    {
        if (extraFee < 0)
            throw new ArgumentException("Extra fee cannot be negative.");

        ExtraFee = extraFee;
    }

    public override void PrintShipment()
    {
        base.PrintShipment();
        Console.WriteLine($"Extra Fee: {ExtraFee:F2}");
        Console.WriteLine($"Final Cost: {EstimatedCost:F2}");
    }
}

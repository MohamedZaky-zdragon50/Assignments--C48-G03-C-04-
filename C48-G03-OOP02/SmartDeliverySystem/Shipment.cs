namespace SmartDeliverySystem;

public class Shipment
{
    public string TrackingCode { get; set; }
    public string Description { get; set; }
    public decimal Weight { get; set; }
    public decimal DeliveryFee { get; private set; }
    public DeliveryAddress Destination { get; set; }

    public virtual decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5);
        }
    }

    public Shipment(
        string trackingCode,
        string description,
        decimal weight,
        decimal deliveryFee,
        DeliveryAddress destination)
    {
        if (string.IsNullOrWhiteSpace(trackingCode))
            throw new ArgumentException("Tracking code cannot be empty.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.");

        if (weight <= 0)
            throw new ArgumentException("Weight must be greater than 0.");

        if (deliveryFee < 0)
            throw new ArgumentException("Delivery fee cannot be negative.");

        TrackingCode = trackingCode;
        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
        Destination = destination;
    }

    // Constructor overloading
    public Shipment(
        string trackingCode,
        string description,
        decimal weight,
        DeliveryAddress destination)
        : this(trackingCode, description, weight, 0, destination)
    {
    }

    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee < 0)
            throw new ArgumentException("Delivery fee cannot be negative.");

        DeliveryFee = newFee;
    }

    public virtual void PrintShipment()
    {
        Console.WriteLine($"Tracking Code: {TrackingCode}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Weight: {Weight} kg");
        Console.WriteLine($"Delivery Fee: {DeliveryFee:F2}");
        Console.WriteLine($"Destination: {Destination}");
        Console.WriteLine($"Estimated Cost: {EstimatedCost:F2}");
    }
}

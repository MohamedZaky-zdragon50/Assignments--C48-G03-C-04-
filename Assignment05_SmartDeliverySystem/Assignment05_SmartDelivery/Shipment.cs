namespace SmartDeliverySystem;

public partial class Shipment
{
    private string trackingCode;
    private string description;
    private decimal weight;
    private decimal deliveryFee;

    public static int TotalShipmentsCreated;

    static Shipment()
    {
        TotalShipmentsCreated = 0;
        Console.WriteLine("Shipment System Initialized");
    }

    public string TrackingCode
    {
        get { return trackingCode; }
    }

    public string Description
    {
        get { return description; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                description = value;
        }
    }

    public decimal Weight
    {
        get { return weight; }
        set
        {
            if (value > 0)
                weight = value;
        }
    }

    public decimal DeliveryFee
    {
        get { return deliveryFee; }
        private set
        {
            if (value > 0)
                deliveryFee = value;
        }
    }

    public DeliveryAddress Destination { get; set; }

    public virtual string ShipmentType
    {
        get { return "Shipment"; }
    }

    public virtual decimal EstimatedCost
    {
        get { return DeliveryFee + (Weight * 5); }
    }

    public Shipment(string trackingCode)
    {
        if (string.IsNullOrWhiteSpace(trackingCode))
            trackingCode = "Unknown";

        this.trackingCode = trackingCode;
        Description = "Unknown";
        Weight = 1;
        DeliveryFee = 50;
        Destination = new DeliveryAddress("Cairo", "Unknown Street", 1);

        TotalShipmentsCreated++;
    }

    public Shipment(string trackingCode, string description, decimal weight,
        decimal deliveryFee, DeliveryAddress destination)
    {
        if (string.IsNullOrWhiteSpace(trackingCode))
            trackingCode = "Unknown";

        this.trackingCode = trackingCode;
        Description = string.IsNullOrWhiteSpace(description) ? "Unknown" : description;
        Weight = weight > 0 ? weight : 1;
        DeliveryFee = deliveryFee > 0 ? deliveryFee : 50;
        Destination = destination ?? new DeliveryAddress("Cairo", "Unknown Street", 1);

        TotalShipmentsCreated++;
    }

    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee > 0)
            DeliveryFee = newFee;
    }

    public virtual void PrintShipment()
    {
        Console.WriteLine("Tracking Code: " + TrackingCode);
        Console.WriteLine("Shipment Type: " + ShipmentType);
        Console.WriteLine("Description: " + Description);
        Console.WriteLine("Weight: " + Weight + " KG");
        Console.WriteLine("Delivery Fee: " + DeliveryFee + " EGP");
        Console.WriteLine("Destination: " + Destination.GetFullAddress());
        Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
        Console.WriteLine("Tracking Status: " + GetTrackingStatus());
    }

    public Shipment CopyShipment()
    {
        return new Shipment(
            TrackingCode,
            Description,
            Weight,
            DeliveryFee,
            new DeliveryAddress(Destination.City, Destination.Street, Destination.BuildingNumber));
    }

    public Shipment ShallowCopy()
    {
        return (Shipment)MemberwiseClone();
    }

    public Shipment DeepCopy()
    {
        Shipment copy = (Shipment)MemberwiseClone();
        copy.Destination = new DeliveryAddress(
            Destination.City,
            Destination.Street,
            Destination.BuildingNumber);
        return copy;
    }

    public static int GetTotalShipmentsCreated()
    {
        return TotalShipmentsCreated;
    }
}

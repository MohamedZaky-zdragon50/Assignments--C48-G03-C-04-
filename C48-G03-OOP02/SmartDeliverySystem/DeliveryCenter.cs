namespace SmartDeliverySystem;

public class DeliveryCenter
{
    public string CenterName { get; set; }

    private Shipment[] shipments;

    public DeliveryCenter(string centerName)
    {
        if (string.IsNullOrWhiteSpace(centerName))
            throw new ArgumentException("Center name cannot be empty.");

        CenterName = centerName;
        shipments = new Shipment[20];
    }

    // search by tracking code
    public Shipment? this[string trackingCode]
    {
        get
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null &&
                    shipments[i].TrackingCode.Equals(
                        trackingCode,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return shipments[i];
                }
            }

            return null;
        }
    }

    // access shipment by position
    public Shipment? this[int index]
    {
        get
        {
            if (index < 0 || index >= shipments.Length)
                return null;

            return shipments[index];
        }
    }

    public bool AddShipment(Shipment shipment)
    {
        if (shipment == null)
            return false;

        // Do not add a shipment with the same tracking code.
        if (this[shipment.TrackingCode] != null)
            return false;

        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] == null)
            {
                shipments[i] = shipment;
                return true;
            }
        }

        return false;
    }

    public bool RemoveShipment(string trackingCode)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] != null &&
                shipments[i].TrackingCode.Equals(
                    trackingCode,
                    StringComparison.OrdinalIgnoreCase))
            {
                shipments[i] = null;
                return true;
            }
        }

        return false;
    }

    public void PrintAllShipments()
    {
        Console.WriteLine();
        Console.WriteLine($"===== {CenterName} - All Shipments =====");

        bool foundShipment = false;

        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] != null)
            {
                shipments[i].PrintShipment();
                foundShipment = true;
            }
        }

        if (!foundShipment)
        {
            Console.WriteLine("No shipments found.");
        }
    }
}

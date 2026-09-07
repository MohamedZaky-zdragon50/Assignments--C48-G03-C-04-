namespace SmartDeliverySystem;

class Program
{
    static void Main(string[] args)
    {
        DeliveryUtilities.PrintSystemTitle();

        DeliveryCenter center = new DeliveryCenter("Main Delivery Center");

        Shipment shipment1 = new StandardShipment(
            "SH001",
            "Laptop",
            3,
            100,
            new DeliveryAddress("Cairo", "Tahrir Street", 15));

        Shipment shipment3 = new ExpressShipment(
            "SH002",
            "Mobile Phone",
            2,
            120,
            new DeliveryAddress("Giza", "Pyramids Street", 20),
            30);

        Shipment shipment4 = new InternationalShipment(
            "SH003",
            "Camera",
            4,
            150,
            new DeliveryAddress("Alexandria", "Corniche Street", 10),
            "UAE",
            50);

        center.AddShipment(shipment1);
        center.AddShipment(shipment3);
        center.AddShipment(shipment4);

        Console.WriteLine("\n Existing Assignment Functionality ");
        center.PrintAllShipments();

        Console.WriteLine("\nSearch using tracking code:");
        Shipment foundShipment = center["SH001"];
        if (foundShipment != null)
            Console.WriteLine("Shipment found: " + foundShipment.TrackingCode + " - " + foundShipment.Description);
        else
            Console.WriteLine("Shipment not found.");

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Object Copying");
        DeliveryUtilities.PrintSeparator();

        Shipment shipment2 = shipment1;
        Console.WriteLine("Reference assignment:");
        Console.WriteLine("shipment1 == shipment2 : " + (shipment1 == shipment2));
        Console.WriteLine("Both variables point to the same object.");

        Shipment copiedShipment = shipment1.CopyShipment();
        Console.WriteLine("\nCopyShipment():");
        Console.WriteLine("shipment1 == copiedShipment : " + (shipment1 == copiedShipment));

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Shallow Copy");
        DeliveryUtilities.PrintSeparator();

        Shipment shallowCopy = shipment1.ShallowCopy();
        Console.WriteLine("Before change:");
        Console.WriteLine("Original City: " + shipment1.Destination.City);
        Console.WriteLine("Copied City: " + shallowCopy.Destination.City);
        Console.WriteLine("Same Shipment object? " + (shipment1 == shallowCopy));
        Console.WriteLine("Same DeliveryAddress object? " + (shipment1.Destination == shallowCopy.Destination));

        shallowCopy.Destination.City = "Giza";

        Console.WriteLine("\nAfter changing copied address:");
        Console.WriteLine("Original City: " + shipment1.Destination.City);
        Console.WriteLine("Copied City: " + shallowCopy.Destination.City);
        Console.WriteLine("The original changed because both shipments share the same DeliveryAddress object.");

        // Put the original address back for the deep-copy test.
        shipment1.Destination.City = "Cairo";

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Deep Copy");
        DeliveryUtilities.PrintSeparator();

        Shipment deepCopy = shipment1.DeepCopy();
        Console.WriteLine("Before change:");
        Console.WriteLine("Original City: " + shipment1.Destination.City);
        Console.WriteLine("Copied City: " + deepCopy.Destination.City);
        Console.WriteLine("Same Shipment object? " + (shipment1 == deepCopy));
        Console.WriteLine("Same DeliveryAddress object? " + (shipment1.Destination == deepCopy.Destination));

        deepCopy.Destination.City = "Giza";

        Console.WriteLine("\nAfter changing copied address:");
        Console.WriteLine("Original City: " + shipment1.Destination.City);
        Console.WriteLine("Copied City: " + deepCopy.Destination.City);
        Console.WriteLine("The original did not change because the DeliveryAddress was copied too.");

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Static Members");
        DeliveryUtilities.PrintSeparator();

        Console.WriteLine("Total Shipments Created : " + Shipment.GetTotalShipmentsCreated());
        Console.WriteLine("The static method is called using the class name, not an object.");

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Extension Methods");
        DeliveryUtilities.PrintSeparator();

        Console.WriteLine(shipment1.GetSummary());
        Console.WriteLine("Is Delivered? " + shipment1.IsDelivered());

        shipment1.UpdateTrackingStatus("Out For Delivery");
        Console.WriteLine("Summary after status update:");
        Console.WriteLine(shipment1.GetSummary());
        Console.WriteLine("Is Delivered? " + shipment1.IsDelivered());

        shipment1.UpdateTrackingStatus("Delivered");
        Console.WriteLine("Summary after delivery:");
        Console.WriteLine(shipment1.GetSummary());
        Console.WriteLine("Is Delivered? " + shipment1.IsDelivered());

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Integer Indexer Test");
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Shipment at index 0: " + center[0].TrackingCode);

        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Remove Shipment Test");
        DeliveryUtilities.PrintSeparator();
        Console.WriteLine("Remove SH003: " + center.RemoveShipment("SH003"));
        Console.WriteLine("Search SH003 after remove: " + (center["SH003"] == null ? "Shipment not found." : "Shipment found."));

        Console.WriteLine("\nProgram finished.");
        Console.ReadKey();
    }
}

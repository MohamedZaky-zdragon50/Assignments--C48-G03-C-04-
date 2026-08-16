namespace SmartDeliverySystem;

public class Program
{
    public static void Main()
    {
        Console.WriteLine(" Smart Delivery Management System ");
        Console.Write("Enter delivery center name: ");
        string centerName = ReadRequiredString();

        DeliveryCenter center = new DeliveryCenter(centerName);

        Console.WriteLine();
        Console.WriteLine("Enter Standard Shipment Data");
        StandardShipment standardShipment = CreateStandardShipment();

        Console.WriteLine();
        Console.WriteLine("Enter Express Shipment Data");
        ExpressShipment expressShipment = CreateExpressShipment();

        Console.WriteLine();
        Console.WriteLine("Enter International Shipment Data");
        InternationalShipment internationalShipment = CreateInternationalShipment();

        center.AddShipment(standardShipment);
        center.AddShipment(expressShipment);
        center.AddShipment(internationalShipment);

        center.PrintAllShipments();

        Console.WriteLine();
        Console.Write("Enter a tracking code to search: ");
        string searchCode = ReadRequiredString();

        Shipment? searchedShipment = center[searchCode];

        if (searchedShipment != null)
        {
            Console.WriteLine();
            Console.WriteLine("Shipment Found:");
            searchedShipment.PrintShipment();
        }
        else
        {
            Console.WriteLine("Shipment was not found.");
        }

        Console.WriteLine();
        Console.Write("Enter a tracking code to remove: ");
        string removeCode = ReadRequiredString();

        bool removed = center.RemoveShipment(removeCode);

        if (removed)
            Console.WriteLine("Shipment removed successfully.");
        else
            Console.WriteLine("Shipment was not found.");

        center.PrintAllShipments();

        Console.WriteLine();
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    static StandardShipment CreateStandardShipment()
    {
        string trackingCode = ReadRequiredString("Tracking code: ");
        string description = ReadRequiredString("Description: ");
        decimal weight = ReadPositiveDecimal("Weight (kg): ");
        decimal deliveryFee = ReadNonNegativeDecimal("Delivery fee: ");
        DeliveryAddress address = ReadAddress();

        return new StandardShipment(
            trackingCode,
            description,
            weight,
            deliveryFee,
            address);
    }

    static ExpressShipment CreateExpressShipment()
    {
        string trackingCode = ReadRequiredString("Tracking code: ");
        string description = ReadRequiredString("Description: ");
        decimal weight = ReadPositiveDecimal("Weight (kg): ");
        decimal deliveryFee = ReadNonNegativeDecimal("Delivery fee: ");
        decimal extraFee = ReadNonNegativeDecimal("Extra fee: ");
        DeliveryAddress address = ReadAddress();

        return new ExpressShipment(
            trackingCode,
            description,
            weight,
            deliveryFee,
            address,
            extraFee);
    }

    static InternationalShipment CreateInternationalShipment()
    {
        string trackingCode = ReadRequiredString("Tracking code: ");
        string description = ReadRequiredString("Description: ");
        decimal weight = ReadPositiveDecimal("Weight (kg): ");
        decimal deliveryFee = ReadNonNegativeDecimal("Delivery fee: ");
        string country = ReadRequiredString("Destination country: ");
        decimal customsFee = ReadNonNegativeDecimal("Customs fee: ");
        DeliveryAddress address = ReadAddress();

        return new InternationalShipment(
            trackingCode,
            description,
            weight,
            deliveryFee,
            address,
            country,
            customsFee);
    }

    static DeliveryAddress ReadAddress()
    {
        Console.WriteLine("Destination Address");

        string city = ReadRequiredString("City: ");
        string street = ReadRequiredString("Street: ");
        int buildingNumber = ReadPositiveInt("Building number: ");

        return new DeliveryAddress(city, street, buildingNumber);
    }

    static string ReadRequiredString(string message = "")
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            Console.WriteLine("Please enter a value.");
        }
    }

    static decimal ReadPositiveDecimal(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (decimal.TryParse(Console.ReadLine(), out decimal value) &&
                value > 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a number greater than 0.");
        }
    }

    static decimal ReadNonNegativeDecimal(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (decimal.TryParse(Console.ReadLine(), out decimal value) &&
                value >= 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a number greater than or equal to 0.");
        }
    }

    static int ReadPositiveInt(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out int value) &&
                value > 0)
            {
                return value;
            }

            Console.WriteLine("Please enter an integer greater than 0.");
        }
    }
}

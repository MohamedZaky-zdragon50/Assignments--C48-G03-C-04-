using System;

// Part 01 : Theoretical Questions

// Question 1
//
// a)
// Answer:
// DeliveryAddress is a struct, and struct is a value type.
// When we copy it, a separate copy of the value is created.
// So, if we modify the copied variable, the original variable
// does not change.
//
// b)
// Answer:
// Customer is a class, and class is a reference type.
// When we copy a class variable, both variables refer to
// the same object in memory.
// So, if one variable modifies the object, the other variable
// sees the same modification.


// Question 2
//
// a)
// Answer:
// 1. The fields are public, so they can be changed directly
//    from outside the class.
// 2. There is no validation for the data.
// 3. The class cannot control how its data is changed.
// 4. Invalid values can be assigned directly.
//
// b) 
// Answer:
// We can make the fields private and access them through
// public properties.
// The properties can contain validation rules and control
// how the data is read or changed.
// This improves encapsulation and protects the object's data.


namespace SmartDelivery_OOP
{

    namespace SmartDelivery_OOP
{
    public struct DeliveryAddress
    {
        public string City;
        public string Street;
        public int BuildingNumber;

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }

        public string GetFullAddress()
        {
            return BuildingNumber + " " + Street + ", " + City;
        }
    }

    public class Shipment
    {
        private string trackingCode;
        private string description;
        private double weight;
        private decimal deliveryFee;
        private DeliveryAddress destination;

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
                {
                    description = value;
                }
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }

        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set
            {
                if (value > 0)
                {
                    deliveryFee = value;
                }
            }
        }

        public DeliveryAddress Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public decimal EstimatedCost
        {
            get { return DeliveryFee + ((decimal)Weight * 5); }
        }

        public Shipment(string trackingCode)
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
            {
                trackingCode = "Unknown";
            }

            this.trackingCode = trackingCode;
            Description = "Unknown";
            Weight = 1;
            DeliveryFee = 50;
            Destination = new DeliveryAddress("Cairo", "Unknown Street", 0);
        }

        public Shipment(
            string trackingCode,
            string description,
            double weight,
            decimal deliveryFee,
            DeliveryAddress destination)
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
            {
                trackingCode = "Unknown";
            }

            this.trackingCode = trackingCode;

            this.description = "Unknown";
            this.weight = 1;
            this.deliveryFee = 50;

            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }

        public void PrintShipment()
        {
            Console.WriteLine("TrackingCode: " + TrackingCode);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Weight: " + Weight + " KG");
            Console.WriteLine("DeliveryFee: " + DeliveryFee + " EGP");
            Console.WriteLine("Destination: " + Destination.GetFullAddress());
            Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
        }
    }

    public class DeliveryCenter
    {
        private Shipment[] shipments = new Shipment[10];

        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                {
                    return shipments[index];
                }

                return null;
            }
            set
            {
                if (index >= 0 && index < shipments.Length)
                {
                    shipments[index] = value;
                }
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null &&
                        shipments[i].TrackingCode == trackingCode)
                    {
                        return shipments[i];
                    }
                }

                return null;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
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
    }

    internal class Program
    {
        static void Main()
        {
            DeliveryCenter center = new DeliveryCenter();

            Console.WriteLine(" Smart Delivery Management System ");
            Console.WriteLine();

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("Enter Shipment " + i + " Data");

                Console.Write("Tracking Code: ");
                string trackingCode = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(trackingCode))
                {
                    Console.Write("Tracking Code cannot be empty. Enter again: ");
                    trackingCode = Console.ReadLine();
                }

                Console.Write("Description: ");
                string description = Console.ReadLine();

                Console.Write("Weight: ");
                double weight;
                while (!double.TryParse(Console.ReadLine(), out weight) || weight <= 0)
                {
                    Console.Write("Weight must be greater than 0. Enter again: ");
                }

                Console.Write("Delivery Fee: ");
                decimal deliveryFee;
                while (!decimal.TryParse(Console.ReadLine(), out deliveryFee) || deliveryFee <= 0)
                {
                    Console.Write("Delivery Fee must be greater than 0. Enter again: ");
                }

                Console.Write("City: ");
                string city = Console.ReadLine();

                Console.Write("Street: ");
                string street = Console.ReadLine();

                Console.Write("Building Number: ");
                int buildingNumber;
                while (!int.TryParse(Console.ReadLine(), out buildingNumber))
                {
                    Console.Write("Enter a valid building number: ");
                }

                DeliveryAddress address =
                    new DeliveryAddress(city, street, buildingNumber);

                Shipment shipment = new Shipment(
                    trackingCode,
                    description,
                    weight,
                    deliveryFee,
                    address);

                if (center.AddShipment(shipment))
                {
                    Console.WriteLine("Shipment added successfully.");
                }
                else
                {
                    Console.WriteLine("Delivery Center is full.");
                }

                Console.WriteLine();
            }

            Console.WriteLine("All Shipments ");

            for (int i = 0; i < 3; i++)
            {
                Shipment shipment = center[i];

                if (shipment != null)
                {
                    Console.WriteLine();
                    shipment.PrintShipment();
                }
            }

            Console.WriteLine();
            Console.Write("Enter a tracking code to search: ");
            string searchCode = Console.ReadLine();

            Shipment foundShipment = center[searchCode];

            if (foundShipment != null)
            {
                Console.WriteLine("Shipment found:");
                Console.WriteLine(
                    foundShipment.TrackingCode + " - " +
                    foundShipment.Description);
            }
            else
            {
                Console.WriteLine("Shipment not found");
            }

            Console.WriteLine();
            Console.WriteLine(" Struct Copy Test ");

            DeliveryAddress originalAddress =
                new DeliveryAddress("Cairo", "Tahrir Street", 15);

            DeliveryAddress copiedAddress = originalAddress;

            copiedAddress.Street = "Makram Ebeid Street";
            copiedAddress.BuildingNumber = 20;

            Console.WriteLine(
                "Original Address: " +
                originalAddress.GetFullAddress());

            Console.WriteLine(
                "Copied Address: " +
                copiedAddress.GetFullAddress());

            Console.WriteLine();
            Console.WriteLine("Press any key to exit ");
            Console.ReadKey();
        }
    }
}

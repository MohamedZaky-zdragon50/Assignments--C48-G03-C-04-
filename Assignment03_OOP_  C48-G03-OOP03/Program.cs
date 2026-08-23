//Assignment 03 - Theoretical Answers

//Q1
//a) Method Overloading means using the same method name with different parameters in the same class.
//Method Overriding means a child class changes the implementation of a virtual method from the parent class.

//b) Static Binding happens at compile time.
//Dynamic Binding happens at runtime and is commonly seen with overridden virtual methods.

//Q2
//a) A sealed class cannot be inherited by another class.

//b) A sealed class stops inheritance from the whole class.
//A sealed method stops further overriding of that method in child classes.

//c) No. A sealed method cannot be overridden again because sealed is used to prevent further overriding.


//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

using System;

namespace SmartDeliveryManagementSystem
{
    // Base class for all shipments
    public class Shipment
    {
        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public double Weight { get; protected set; }
        public double DeliveryFee { get; set; }


        public virtual double EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }

        public DeliveryAddress Address { get; private set; }

        public Shipment(string trackingCode, string description, double weight,
                        double deliveryFee, DeliveryAddress address)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Address = address;
        }

        public void UpdateWeight(double newWeight)
        {
            Weight = newWeight;
        }

        public void UpdateWeight(double newWeight, double extraPackingWeight)
        {
            Weight = newWeight + extraPackingWeight;
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine("Shipment");
            Console.WriteLine("Tracking Code:"+ TrackingCode);
            Console.WriteLine("Description:"+ Description);
            Console.WriteLine("Weight:" + Weight +"KG");
            Console.WriteLine("Delivery Fee:" + DeliveryFee + "EGP");
            Console.WriteLine("Estimated Cost:" + EstimatedCost + "EGP");
        }
    }

    public class StandardShipment : Shipment
    {
        public StandardShipment(string trackingCode, string description, double weight,
                                double deliveryFee, DeliveryAddress address)
            : base(trackingCode, description, weight, deliveryFee, address)
        {
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            Console.WriteLine("Tracking Code:"+ TrackingCode);
            Console.WriteLine("Description:"+ Description);
            Console.WriteLine("Weight:" + Weight +"KG");
            Console.WriteLine("Delivery Fee:" + DeliveryFee + "EGP");
            Console.WriteLine("Estimated Cost:" + EstimatedCost + "EGP");
        }
    }

    public class ExpressShipment : Shipment
    {
        public double ExtraFee { get; set; }

        public ExpressShipment(string trackingCode, string description, double weight,
                               double deliveryFee, double extraFee, DeliveryAddress address)
            : base(trackingCode, description, weight, deliveryFee, address)
        {
            ExtraFee = extraFee;
        }

        public override double EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + ExtraFee;
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");
            Console.WriteLine("Tracking Code:"+ TrackingCode);
            Console.WriteLine("Description:"+ Description);
            Console.WriteLine("Weight:" + Weight +"KG");
            Console.WriteLine("Delivery Fee:" + DeliveryFee + "EGP");
            Console.WriteLine("Extra Fee:" + ExtraFee + "EGP");
            Console.WriteLine("Estimated Cost:" + EstimatedCost + "EGP");
        }
    }

    public class InternationalShipment : Shipment
    {
        public string DestinationCountry { get; set; }
        public double CustomsFee { get; set; }

        public InternationalShipment(string trackingCode, string description, double weight,
                                     double deliveryFee, string destinationCountry,
                                     double customsFee, DeliveryAddress address)
            : base(trackingCode, description, weight, deliveryFee, address)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override double EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + CustomsFee;
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine("Tracking Code:"+ TrackingCode);
            Console.WriteLine("Description:"+ Description);
            Console.WriteLine("Weight:" + Weight +"KG");
            Console.WriteLine("Delivery Fee:" + DeliveryFee + "EGP");
            Console.WriteLine("Destination Country:" + DestinationCountry);
            Console.WriteLine("Customs Fee:" + CustomsFee + "EGP");
            Console.WriteLine("Estimated Cost:" + EstimatedCost + "EGP");
        }

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("Customs Report Generated.");
        }
    }

    public class PriorityInternationalShipment : InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode, string description,
                                             double weight, double deliveryFee,
                                             string destinationCountry, double customsFee,
                                             DeliveryAddress address)
            : base(trackingCode, description, weight, deliveryFee,
                   destinationCountry, customsFee, address)
        {
        }

        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine("Priority Customs Report Generated.");
        }
    }

    public sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode, string description, double weight,
                                 double deliveryFee, DeliveryAddress address)
            : base(trackingCode, description, weight, deliveryFee, address)
        {
        }
    }

    public class Driver
    {
        public int DriverId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public Driver(int driverId, string fullName, string phoneNumber)
        {
            DriverId = driverId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }
    }

    public class DeliveryAddress
    {
        public string City { get; set; }
        public string Street { get; set; }

        public DeliveryAddress(string city, string street)
        {
            City = city;
            Street = street;
        }
    }

    public class DeliveryCenter
    {
        private Shipment[] shipments;
        private int shipmentCount;

        public Driver Driver { get; set; }

        public DeliveryCenter(int size)
        {
            shipments = new Shipment[size];
            shipmentCount = 0;
        }

        public void AddShipment(Shipment shipment)
        {
            if (shipmentCount < shipments.Length)
            {
                shipments[shipmentCount] = shipment;
                shipmentCount++;
            }
            else
            {
                Console.WriteLine("The delivery center is full.");
            }
        }

        public void RemoveShipment(int index)
        {
            if (index >= 0 && index < shipmentCount)
            {
                for (int i = index; i < shipmentCount - 1; i++)
                {
                    shipments[i] = shipments[i + 1];
                }

                shipments[shipmentCount - 1] = null;
                shipmentCount--;
            }
        }

        public Shipment this[int index]
        {
            get
            {
                return shipments[index];
            }
            set
            {
                shipments[index] = value;
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipmentCount; i++)
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

        public void PrintAllShipments()
        {
            Console.WriteLine("Delivery Center");
            Console.WriteLine("Driver:" + Driver.FullName);

            for (int i = 0; i < shipmentCount; i++)
            {
                Console.WriteLine("------------------------------------------");
                shipments[i].PrintShipment();
            }
        }
    }

    public static class DeliveryHelper
    {
        public static void PrintShipmentDetails(Shipment shipment)
        {
            shipment.PrintShipment();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // a. 
            Driver driver = new Driver(1, "Ahmed Mohamed", "01234567890");

            // b.
            DeliveryCenter center = new DeliveryCenter(10);

            // c.
            center.Driver = driver;

            
            DeliveryAddress address1 = new DeliveryAddress("Cairo", "Nasr City");
            DeliveryAddress address2 = new DeliveryAddress("Giza", "Dokki");
            DeliveryAddress address3 = new DeliveryAddress("Berlin", "Main Street");

            StandardShipment standard = new StandardShipment(
                "SH001", "Laptop", 3, 80, address1);

            // e. 
            ExpressShipment express = new ExpressShipment(
                "SH002", "Mobile Phone", 2, 60, 30, address2);

            // f. 
            InternationalShipment international = new InternationalShipment(
                "SH003", "Television", 8, 120, "Germany", 100, address3);

            // g. 
            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);

            // h. 
            center.PrintAllShipments();

            // i. 
            Console.WriteLine("Printing Using DeliveryHelper");
            DeliveryHelper.PrintShipmentDetails(standard);
            Console.WriteLine("Standard Shipment Printed Successfully.");
            DeliveryHelper.PrintShipmentDetails(express);
            Console.WriteLine("Express Shipment Printed Successfully.");
            DeliveryHelper.PrintShipmentDetails(international);
            Console.WriteLine("International Shipment Printed Successfully.");

            // j. 
            Console.WriteLine("Updating Weight...");

            Console.WriteLine("Original Weight : " + standard.Weight + " KG");

            standard.UpdateWeight(5);
            Console.WriteLine("Updated Weight : " + standard.Weight + " KG");

            standard.UpdateWeight(5, 0.5);
            Console.WriteLine("Updated Weight After Packing : " + standard.Weight + " KG");

            // k.
            Console.WriteLine("Printing Using Shipment[]...");

            Shipment[] allShipments = { standard, express, international };

            foreach (Shipment shipment in allShipments)
            {
                shipment.PrintShipment();
                Console.WriteLine("------------------------------------------");
            }

            // l. Sealed class demonstration
            // CompletedShipment is sealed, so this is NOT allowed:
            // class MyShipment : CompletedShipment { }

            // Sealed method demonstration:
            PriorityInternationalShipment priority =
                new PriorityInternationalShipment(
                    "SH004", "Documents", 1, 100, "France", 50, address3);

            priority.GenerateCustomsReport();

            // The following is NOT allowed because GenerateCustomsReport()
            // is sealed in PriorityInternationalShipment:
            // class MyPriorityShipment : PriorityInternationalShipment
            // {
            //     public override void GenerateCustomsReport() { }
            // }

            Console.WriteLine("Program finished.");
        }
    }
}

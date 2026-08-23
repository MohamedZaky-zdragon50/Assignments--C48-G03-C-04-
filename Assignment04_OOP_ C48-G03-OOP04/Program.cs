//ASSIGNMENT 04 - THEORETICAL ANSWERS

//Q1 - Abstraction

//a) Abstraction means hiding unnecessary implementation details and showing the important part of an object.

//b) Abstraction is one of the four pillars of OOP because it allows us to focus on what an object does without needing to know all of its internal details.

//Q2 -Abstract Classes vs. Interfaces

//a) An abstract class can contain normal members, constructors, properties, methods, and abstract members.An interface is mainly a contract that tells a class what members it must implement.

//b) I would choose an interface when different classes need to follow the same behavior or contract, even if they do not belong to the same class hierarchy.

//c) A class cannot inherit from multiple abstract classes because C# does not support multiple class inheritance. A class can implement multiple interfaces.


using System;

namespace SmartDeliveryManagementSystem
{
    public abstract class Shipment
    {
        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; protected set; }
        public decimal DeliveryFee { get; set; }
        public DeliveryAddress Destination { get; set; }

        public Shipment(string trackingCode, string description, decimal weight,
                        decimal deliveryFee, DeliveryAddress destination)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        public abstract decimal EstimatedCost { get; }
        public abstract void PrintShipment();

        public void UpdateWeight(decimal newWeight)
        {
            Weight = newWeight;
        }

        public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
        {
            Weight = newWeight + extraPackingWeight;
        }
    }

    public interface ITrackable
    {
        string GetTrackingStatus();
    }

    public interface IInsurable
    {
        decimal CalculateInsurance();
    }

    public class StandardShipment : Shipment, ITrackable, IInsurable
    {
        public StandardShipment(string trackingCode, string description, decimal weight,
                                decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5); }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            Console.WriteLine("Tracking Code:" + TrackingCode);
            Console.WriteLine("Description:" + Description);
            Console.WriteLine("Weight:" + Weight + "KG");
            Console.WriteLine("Delivery Fee:" + DeliveryFee + "EGP");
            Console.WriteLine("Estimated Cost:" + EstimatedCost + "EGP");
        }

        public string GetTrackingStatus()
        {
            return "Shipment " + TrackingCode + " is Ready.";
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m;
        }
    }

    public class ExpressShipment : Shipment, ITrackable, IInsurable
    {
        public decimal ExtraFee { get; set; }

        public ExpressShipment(string trackingCode, string description, decimal weight,
                                decimal deliveryFee, decimal extraFee,
                                DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5) + ExtraFee; }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");
            Console.WriteLine("Tracking Code:" + TrackingCode);
            Console.WriteLine("Description:" + Description);
            Console.WriteLine("Weight:" + Weight + "KG");
            Console.WriteLine("Delivery Fee:" + DeliveryFee + "EGP");
            Console.WriteLine("Extra Fee:" + ExtraFee + "EGP");
            Console.WriteLine("Estimated Cost:" + EstimatedCost + "EGP");
        }

        public string GetTrackingStatus()
        {
            return "Shipment " + TrackingCode + " is Out for Delivery.";
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.08m;
        }
    }

    public class InternationalShipment : Shipment, ITrackable, IInsurable
    {
        public string DestinationCountry { get; set; }
        public decimal CustomsFee { get; set; }

        public InternationalShipment(string trackingCode, string description, decimal weight,
                                      decimal deliveryFee, string destinationCountry,
                                      decimal customsFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5) + CustomsFee; }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine("Tracking Code:" + TrackingCode);
            Console.WriteLine("Description:" + Description);
            Console.WriteLine("Weight:" + Weight + "KG");
            Console.WriteLine("Delivery Fee:" + DeliveryFee + "EGP");
            Console.WriteLine("Destination Country:" + DestinationCountry);
            Console.WriteLine("Customs Fee:" + CustomsFee + "EGP");
            Console.WriteLine("Estimated Cost:" + EstimatedCost + "EGP");
        }

        public string GetTrackingStatus()
        {
            return "Shipment " + TrackingCode + " has been Delivered.";
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m;
        }

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("Customs Report Generated.");
        }
    }

    public sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode, string description, decimal weight,
                                 decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5); }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Completed Shipment");
            Console.WriteLine("Tracking Code : " + TrackingCode);
            Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
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
            get { return shipments[index]; }
            set { shipments[index] = value; }
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

            if (Driver != null)
            {
                Console.WriteLine("Driver:" + Driver.FullName);
            }

            for (int i = 0; i < shipmentCount; i++)
            {
                Console.WriteLine("------------------------------------------");
                shipments[i].PrintShipment();
            }

        }

        public void PrintTrackingStatuses()
        {
            Console.WriteLine("Tracking Status");

            for (int i = 0; i < shipmentCount; i++)
            {
                ITrackable shipment = shipments[i] as ITrackable;

                if (shipment != null)
                {
                    Console.WriteLine(shipment.GetTrackingStatus());
                }
            }

        }

        public Shipment[] GetShipments()
        {
            Shipment[] result = new Shipment[shipmentCount];

            for (int i = 0; i < shipmentCount; i++)
            {
                result[i] = shipments[i];
            }

            return result;
        }
    }

    public static class DeliveryReport
    {
        public static void PrintShipment(ITrackable shipment)
        {
            Console.WriteLine(shipment.GetTrackingStatus());
        }

        public static void PrintInsurance(IInsurable shipment)
        {
            Console.WriteLine("Insurance Cost : " + shipment.CalculateInsurance() + " EGP");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver(1, "Ahmed Mohamed", "01234567890");

            DeliveryCenter center = new DeliveryCenter(10);
            center.Driver = driver;

            DeliveryAddress address1 = new DeliveryAddress("Cairo", "Nasr City");
            DeliveryAddress address2 = new DeliveryAddress("Giza", "Dokki");
            DeliveryAddress address3 = new DeliveryAddress("Berlin", "Main Street");

            StandardShipment standard =
                new StandardShipment("SH001", "Laptop", 3m, 80m, address1);

            ExpressShipment express =
                new ExpressShipment("SH002", "Mobile Phone", 2m, 60m, 30m, address2);

            InternationalShipment international =
                new InternationalShipment("SH003", "Television", 8m, 120m,
                                           "Germany", 100m, address3);

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);

            center.PrintAllShipments();

            center.PrintTrackingStatuses();

            Console.WriteLine("Insurance");
            Console.WriteLine("Standard Shipment Insurance : "
                              + standard.CalculateInsurance() + " EGP");
            Console.WriteLine("Express Shipment Insurance : "
                              + express.CalculateInsurance() + " EGP");
            Console.WriteLine("International Shipment Insurance : "
                              + international.CalculateInsurance() + " EGP");

            Console.WriteLine("ITrackable[]");

            ITrackable[] trackableShipments =
            {
                standard,
                express,
                international
            };

            for (int i = 0; i < trackableShipments.Length; i++)
            {
                Console.WriteLine(trackableShipments[i].GetTrackingStatus());
            }

            Console.WriteLine("IInsurable[]");

            IInsurable[] insurableShipments =
            {
                standard,
                express,
                international
            };

            for (int i = 0; i < insurableShipments.Length; i++)
            {
                Console.WriteLine("Insurance : "
                                  + insurableShipments[i].CalculateInsurance()
                                  + " EGP");
            }

            Console.WriteLine("DeliveryReport");

            DeliveryReport.PrintShipment(standard);
            DeliveryReport.PrintShipment(express);
            DeliveryReport.PrintShipment(international);

            DeliveryReport.PrintInsurance(standard);
            DeliveryReport.PrintInsurance(express);
            DeliveryReport.PrintInsurance(international);

            Console.WriteLine("Interface Polymorphism Demonstrated Successfully.");
        }
    }
}

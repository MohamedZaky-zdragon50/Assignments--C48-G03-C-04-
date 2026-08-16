namespace SmartDeliverySystem;

public struct DeliveryAddress
{
    public string City;
    public string Street;
    public int BuildingNumber;

    public DeliveryAddress(string city, string street, int buildingNumber)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty.");

        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be empty.");

        if (buildingNumber <= 0)
            throw new ArgumentException("Building number must be greater than 0.");

        City = city;
        Street = street;
        BuildingNumber = buildingNumber;
    }

    public override string ToString()
    {
        return $"{BuildingNumber}, {Street}, {City}";
    }
}

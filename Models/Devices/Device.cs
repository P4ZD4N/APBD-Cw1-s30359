using APBD_Cw1_s30359.Exceptions;
using APBD_Cw1_s30359.models.rentals;
using APBD_Cw1_s30359.Models.Users;

namespace APBD_Cw1_s30359.Models.Devices;

public abstract class Device
{
    public string Manufacturer { get; }
    public string Name { get; }
    public int ProductionYear { get; }
    public string SerialNumber { get; }
    protected bool IsAvailable { get; set; }

    private static List<Device> AllDevices { get; } = new();

    protected Device(string manufacturer, string name, int productionYear, string serialNumber)
    {
        Manufacturer = manufacturer;
        Name = name;
        ProductionYear = productionYear;
        SerialNumber = serialNumber;
        IsAvailable = true;
        
        AllDevices.Add(this);
    }

    public static void DisplayAllDevicesWithStatus()
    {
        Console.WriteLine("Currently owned devices: ");
        foreach (var device in AllDevices)
        {
            Console.WriteLine(device);
        }
    }
    
    public static void DisplayAvailableDevices()
    {
        Console.WriteLine("Currently available devices: ");
        foreach (var device in AllDevices)
        {
            if (device.IsAvailable)
            {
                Console.WriteLine(device);
            }
        }
    }

    public void Rent(Person renter, DateTime rentalStart, DateTime rentalEnd)
    {
        if (rentalEnd < rentalStart)
        {
            throw new RentalDateTimeException();
        }
        
        var rental = new Rental(renter, this, rentalStart, rentalEnd);
        
        IsAvailable = false;
        
        Console.WriteLine($"[{renter.FirstName} {renter.LastName}] New rental with ID {rental.Id} ({GetType().Name})");
    }
}
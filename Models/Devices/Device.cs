namespace APBD_Cw1_s30359.Models.Devices;

public abstract class Device
{
    public string Manufacturer { get; }
    public string Name { get; }
    public int ProductionYear { get; }
    public string SerialNumber { get; }
    public bool IsAvailable { get; set; }

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

}
namespace APBD_Cw1_s30359.Models.Devices;

public abstract class Device
{
    public string Manufacturer { get; }
    public string Name { get; }
    public int ProductionYear { get; }
    public string SerialNumber { get; }
    public bool IsAvailable { get; set; }

    public static List<Device> AllDevices { get; } = new();

    protected Device(string manufacturer, string name, int productionYear, string serialNumber)
    {
        Manufacturer = manufacturer;
        Name = name;
        ProductionYear = productionYear;
        SerialNumber = serialNumber;
        IsAvailable = true;
        
        AllDevices.Add(this);
    }
}
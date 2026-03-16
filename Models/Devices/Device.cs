namespace APBD_Cw1_s30359.Models.Devices;

public abstract class Device(string manufacturer, string name, int productionYear, string serialNumber)
{
    public string Manufacturer { get; } = manufacturer;
    public string Name { get; } = name;
    public int ProductionYear { get; } = productionYear;
    public string SerialNumber { get; } = serialNumber;
    public bool IsAvailable { get; set; } = true;
}
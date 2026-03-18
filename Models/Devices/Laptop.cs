namespace APBD_Cw1_s30359.Models.Devices;

public class Laptop : Device {
    public int Id { get; }
    
    private static int _laptopCount = 1;

    public Laptop(string manufacturer, string name, int productionYear, string serialNumber)
        : base(manufacturer, name, productionYear, serialNumber)
    {
        Id = _laptopCount;
        _laptopCount++;
    }
}
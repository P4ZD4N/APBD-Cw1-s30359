namespace APBD_Cw1_s30359.Models.Devices;

public class Laptop : Device {
    public int Id { get; }
    public int RamGb { get; set; }
    public bool IsTouchscreen { get; }
    
    private static int _laptopCount = 1;

    public Laptop(string manufacturer, string name, int productionYear, string serialNumber, int ramGb, bool isTouchscreen)
        : base(manufacturer, name, productionYear, serialNumber)
    {
        Id = _laptopCount;
        _laptopCount++;

        RamGb = ramGb;
        IsTouchscreen = isTouchscreen;
    }
    
    public override string ToString()
    {
        return $"{GetType().Name} (ID {Id}): {(IsAvailable ? "Available" : "Not Available")}";
    }
}
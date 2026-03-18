namespace APBD_Cw1_s30359.Models.Devices;

public class Projector : Device {
    public int Id { get; }
    
    private static int _projectorCount = 1;

    public Projector(string manufacturer, string name, int productionYear, string serialNumber)
        : base(manufacturer, name, productionYear, serialNumber)
    {
        Id = _projectorCount;
        _projectorCount++;
    }
}
namespace APBD_Cw1_s30359.Models.Devices;

public class Camera : Device {
    public int Id { get; }
    
    private static int _cameraCount = 1;

    public Camera(string manufacturer, string name, int productionYear, string serialNumber)
        : base(manufacturer, name, productionYear, serialNumber)
    {
        Id = _cameraCount;
        _cameraCount++;
    }
}
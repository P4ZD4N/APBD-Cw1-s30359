using APBD_Cw1_s30359.models.rentals;
using APBD_Cw1_s30359.Models.Users;

namespace APBD_Cw1_s30359.Models.Devices;

public class Camera : Device {
    public int Id { get; }
    public int Resolution { get; }
    public bool HasFlash { get; }
    
    private static int _cameraCount = 1;

    public Camera(string manufacturer, string name, int productionYear, string serialNumber, int resolution, bool hasFlash)
        : base(manufacturer, name, productionYear, serialNumber)
    {
        Id = _cameraCount;
        _cameraCount++;

        Resolution = resolution;
        HasFlash = hasFlash;
    }
    
    public override string ToString()
    {
        return $"{GetType().Name} (ID {Id}): {(IsAvailable ? "Available" : "Not Available")}";
    }
}
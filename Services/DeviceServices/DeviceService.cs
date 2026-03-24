using ModelDevice = APBD_Cw1_s30359.Models.Devices;

namespace APBD_Cw1_s30359.Services.DeviceServices;

public class DeviceService : IDeviceService
{
    public void DisplayAllDevicesWithStatus()
    {
        Console.WriteLine();
        Console.WriteLine("All device list: ");
        foreach (var device in ModelDevice.Device.AllDevices)
        {
            Console.WriteLine(device);
        }
    }
    
    public void DisplayAvailableDevices()
    {
        Console.WriteLine();
        Console.WriteLine("Currently available devices: ");
        foreach (var device in ModelDevice.Device.AllDevices.Where(device => device.IsAvailable))
        {
            Console.WriteLine(device);
        }
    }
}
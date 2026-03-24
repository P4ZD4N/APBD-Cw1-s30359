using ModelDevice = APBD_Cw1_s30359.Models.Devices;

namespace APBD_Cw1_s30359.Services.ReportServices;

public class ReportService : IReportService
{
    public void DisplayReportAboutCurrentState()
    {
        Console.WriteLine();
        Console.WriteLine("Report about current state: ");
        
        DisplayDevicesInOffer();
        DisplayAvailableDevices(true);
        DisplayAvailableDevices(false);
    }

    private void DisplayDevicesInOffer()
    {
        Console.WriteLine($"{ModelDevice.Device.AllDevices.Count} devices in offer");
        Console.WriteLine($"- {ModelDevice.Device.AllDevices.Count(device => device is ModelDevice.Camera)} cameras");
        Console.WriteLine($"- {ModelDevice.Device.AllDevices.Count(device => device is ModelDevice.Laptop)} laptops");
        Console.WriteLine($"- {ModelDevice.Device.AllDevices.Count(device => device is ModelDevice.Projector)} projectors");
    }
    
    private void DisplayAvailableDevices(bool available)
    {
        var devices = ModelDevice.Device.AllDevices
            .Where(device => device.IsAvailable == available)
            .ToList();

        Console.WriteLine($"{devices.Count} devices {(available ? "available" : "unavailable")}");
        Console.WriteLine($"- {devices.Count(device => device is ModelDevice.Camera)} cameras");
        Console.WriteLine($"- {devices.Count(device => device is ModelDevice.Laptop)} laptops");
        Console.WriteLine($"- {devices.Count(device => device is ModelDevice.Projector)} projectors");
    }
}
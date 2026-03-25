using APBD_Cw1_s30359.Models.Devices;

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
        Console.WriteLine($"{Device.AllDevices.Count} devices in offer");
        Console.WriteLine($"- {Device.AllDevices.Count(device => device is Camera)} cameras");
        Console.WriteLine($"- {Device.AllDevices.Count(device => device is Laptop)} laptops");
        Console.WriteLine($"- {Device.AllDevices.Count(device => device is Projector)} projectors");
    }
    
    private void DisplayAvailableDevices(bool available)
    {
        var devices = Device.AllDevices
            .Where(device => device.IsAvailable == available)
            .ToList();

        Console.WriteLine($"{devices.Count} devices {(available ? "available" : "unavailable")}");
        Console.WriteLine($"- {devices.Count(device => device is Camera)} cameras");
        Console.WriteLine($"- {devices.Count(device => device is Laptop)} laptops");
        Console.WriteLine($"- {devices.Count(device => device is Projector)} projectors");
    }
}
using APBD_Cw1_s30359.Exceptions;
using APBD_Cw1_s30359.Models.Devices;
using APBD_Cw1_s30359.Models.Users;

namespace APBD_Cw1_s30359.Services;

public static class RentalValidatorService
{
    public static void ValidateDates(DateTime start, DateTime end)
    {
        if (end < start)
            throw new RentalDateTimeException();
    }

    public static void ValidateDeviceAvailability(Device device)
    {
        if (!device.IsAvailable)
            throw new DeviceAlreadyRentedException();
    }

    public static void ValidateRentalLimit(Person renter)
    {
        var employeeLimit = renter is Employee && renter.NumberOfDevicesRenter >= 5;
        var studentLimit = renter is Student && renter.NumberOfDevicesRenter >= 2;

        if (employeeLimit || studentLimit)
            throw new RentalMaximumException();
    }
}
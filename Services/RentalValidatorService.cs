using APBD_Cw1_s30359.Exceptions;
using APBD_Cw1_s30359.Models.Devices;
using APBD_Cw1_s30359.Models.Users;

namespace APBD_Cw1_s30359.Services;

public static class RentalValidatorService
{
    private const int EmployeeRentalLimit = 5;
    private const int StudentRentalLimit = 2;
    
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
        var employeeLimitExceeded = renter is Employee && renter.NumberOfDevicesRenter >= EmployeeRentalLimit;
        var studentLimitExceeded = renter is Student && renter.NumberOfDevicesRenter >= StudentRentalLimit;

        if (employeeLimitExceeded || studentLimitExceeded)
            throw new RentalMaximumExceededException();
    }
}
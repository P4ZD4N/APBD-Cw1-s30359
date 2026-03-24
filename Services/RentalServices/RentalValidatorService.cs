using APBD_Cw1_s30359.Exceptions;
using APBD_Cw1_s30359.Exceptions.Device;
using APBD_Cw1_s30359.Models.Users;

namespace APBD_Cw1_s30359.Services.RentalServices;

public class RentalValidatorService : IValidatorService
{
    public void ValidateDates(DateTime start, DateTime end)
    {
        if (end < start)
            throw new RentalDateTimeException();
    }

    public void ValidateDeviceAvailability(Models.Devices.Device device)
    {
        if (!device.IsAvailable)
            throw new DeviceAlreadyRentedException();
    }

    public void ValidateRentalLimit(Person renter)
    {
        if (renter.NumberOfDevicesRenter >= renter.GetRentalLimit())
            throw new RentalMaximumExceededException();
    }
}
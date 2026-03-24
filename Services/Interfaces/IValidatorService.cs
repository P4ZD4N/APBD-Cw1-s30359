using APBD_Cw1_s30359.Models.Devices;
using APBD_Cw1_s30359.Models.Users;

namespace APBD_Cw1_s30359.Services;

public interface IValidatorService
{
    public void ValidateDates(DateTime start, DateTime end);
    public void ValidateDeviceAvailability(Device device);
    public void ValidateRentalLimit(Person renter);
}
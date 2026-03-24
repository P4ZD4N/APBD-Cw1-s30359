using APBD_Cw1_s30359.Models.Devices;
using APBD_Cw1_s30359.Models.Rentals;
using APBD_Cw1_s30359.Models.Users;

namespace APBD_Cw1_s30359.Services;

public interface IRentalService
{
    public void StartRental(Person renter, Device rentedDevice, DateTime rentalStart, DateTime rentalEnd);
    public void EndRental(int id);
    public void DisplayRentalsForPerson(Person person);
    public void DisplayRentalsAfterDeadline();
}
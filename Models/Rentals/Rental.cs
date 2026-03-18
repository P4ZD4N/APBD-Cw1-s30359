using APBD_Cw1_s30359.Models.Devices;
using APBD_Cw1_s30359.Models.Users;

namespace APBD_Cw1_s30359.models.rentals;

public class Rental
{
    public int Id { get; }
    public Person Renter { get; }
    public Device RentedDevice { get; }
    public DateTime RentalStart { get; }
    public DateTime RentalEnd { get; set; }
    public DateTime RealRentalEnd { get; set; }
    
    private static int _rentalCount = 1;

    public Rental(Person renter, Device rentedDevice, DateTime rentalStart, DateTime rentalEnd)
    {
        Id = _rentalCount;
        _rentalCount++;
        
        Renter = renter;
        RentedDevice = rentedDevice;
        RentalStart = rentalStart;
        RentalEnd = rentalEnd;
    }
}
using APBD_Cw1_s30359.Models.Devices;
using APBD_Cw1_s30359.Models.Users;

namespace APBD_Cw1_s30359.Models.Rentals;

public class Rental
{
    public int Id { get; }
    public Person Renter { get; }
    public Device RentedDevice { get; }
    public DateTime RentalStart { get; set; }
    public DateTime RentalEnd { get; set; }
    public DateTime RealRentalEnd { get; set; }
    
    private static int _rentalCount = 1;
    public static List<Rental> AllRentals { get; } = new();

    public Rental(Person renter, Device rentedDevice, DateTime rentalStart, DateTime rentalEnd)
    {
        Id = _rentalCount;
        _rentalCount++;
        
        Renter = renter;
        RentedDevice = rentedDevice;
        RentalStart = rentalStart;
        RentalEnd = rentalEnd;
        
        rentedDevice.IsAvailable = false;
        renter.NumberOfDevicesRenter++;
        
        AllRentals.Add(this);
    }
    
    public override string ToString()
    {
        return $"[{Renter.FirstName} {Renter.LastName}] " +
               $"Active rental with ID {Id} ({RentedDevice.GetType().Name}) end deadline at {RentalEnd:yyyy-MM-dd HH:mm}";
    }
}
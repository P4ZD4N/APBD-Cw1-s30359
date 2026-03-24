using APBD_Cw1_s30359.Exceptions;
using APBD_Cw1_s30359.Models.Devices;
using APBD_Cw1_s30359.Models.Rentals;
using APBD_Cw1_s30359.Models.Users;

namespace APBD_Cw1_s30359.Services.RentalServices;

public class RentalService : IRentalService
{
    private readonly IValidatorService _validatorService = new RentalValidatorService();
    private readonly IFineService _fineService = new RentalFineService();

    public void StartRental(Person renter, Device rentedDevice, DateTime rentalStart, DateTime rentalEnd) {
        _validatorService.ValidateDates(rentalStart, rentalEnd);
        _validatorService.ValidateDeviceAvailability(rentedDevice);
        _validatorService.ValidateRentalLimit(renter);
        
        var rental = new Rental(renter, rentedDevice, rentalStart, rentalEnd);

        Console.WriteLine(
            $"[{renter.FirstName} {renter.LastName}] " +
            $"New rental with ID {rental.Id} ({rental.RentedDevice.GetType().Name})");
    }
    
    public void EndRental(int id)
    {
        var foundRental = Rental.AllRentals
            .FirstOrDefault(rental => rental.Id == id);

        if (foundRental == null)
        {
            throw new RentalNotFoundException();
        }
        
        var realRentalEnd = DateTime.Now;
        
        Console.WriteLine();
        Console.WriteLine(
            $"[{foundRental.Renter.FirstName} {foundRental.Renter.LastName}] " +
            $"Rental with ID {foundRental.Id} ({foundRental.RentedDevice.GetType().Name}) end deadline at {foundRental.RentalEnd:yyyy-MM-dd HH:mm}");
        Console.WriteLine(
            $"[{foundRental.Renter.FirstName} {foundRental.Renter.LastName}] " +
            $"Ended rental with ID {foundRental.Id} ({foundRental.RentedDevice.GetType().Name}) at {realRentalEnd:yyyy-MM-dd HH:mm}");

        _fineService.CheckIfFineNecessary(foundRental, realRentalEnd);
        
        foundRental.RealRentalEnd = realRentalEnd;
        foundRental.RentedDevice.IsAvailable = true;
        foundRental.Renter.NumberOfDevicesRenter--;
        
        Rental.AllRentals.Remove(foundRental);
    }

    public void DisplayRentalsForPerson(Person person)
    {
        var rentals = Rental.AllRentals.Where(rental =>
            rental.Renter is Employee emp && person is Employee e && emp.Id == e.Id ||
            rental.Renter is Student st && person is Student s && st.Id == s.Id
        );

        Console.WriteLine();
        Console.WriteLine($"Rentals for {person.FirstName} {person.LastName}: ");
        foreach (var rental in rentals)
        {
            Console.WriteLine(rental);
        }
    }
    
    public void DisplayRentalsAfterDeadline()
    {
        var rentalsAfterDeadline = Rental.AllRentals.Where(rental => DateTime.Now > rental.RentalEnd);
        
        Console.WriteLine();
        Console.WriteLine("Rentals after deadline: ");
        foreach (var rental in rentalsAfterDeadline)
        {
            Console.WriteLine(rental);
        }
    }
}
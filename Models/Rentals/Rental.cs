using APBD_Cw1_s30359.Exceptions;
using APBD_Cw1_s30359.Models.Devices;
using APBD_Cw1_s30359.Models.Users;

namespace APBD_Cw1_s30359.models.rentals;

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
        if (rentalEnd < rentalStart)
        {
            throw new RentalDateTimeException();
        }

        if (!rentedDevice.IsAvailable)
        {
            throw new DeviceAlreadyRentedException();
        }
        
        var employeeReachedMaximumRentals = renter is Employee && renter.NumberOfDevicesRenter >= 5;
        var studentReachedMaximumRentals = renter is Student && renter.NumberOfDevicesRenter >= 2;

        if (employeeReachedMaximumRentals || studentReachedMaximumRentals)
        {
            throw new RentalMaximumException();
        }
        
        Id = _rentalCount;
        _rentalCount++;
        
        Renter = renter;
        RentedDevice = rentedDevice;
        RentalStart = rentalStart;
        RentalEnd = rentalEnd;
        
        AllRentals.Add(this);
        
        rentedDevice.IsAvailable = false;
        renter.NumberOfDevicesRenter++;
        
        Console.WriteLine($"[{renter.FirstName} {renter.LastName}] New rental with ID {Id} ({RentedDevice.GetType().Name})");
    }

    public void End()
    {
        DateTime now = DateTime.Now;
        TimeSpan difference = now - RentalEnd; 

        Console.WriteLine();
        Console.WriteLine($"[{Renter.FirstName} {Renter.LastName}] Rental with ID {Id} ({RentedDevice.GetType().Name}) end deadline at {RentalEnd:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"[{Renter.FirstName} {Renter.LastName}] Ended rental with ID {Id} ({RentedDevice.GetType().Name}) at {now:yyyy-MM-dd HH:mm}");

        if (now > RentalEnd)
        {
            int lateDays = (int) Math.Ceiling(difference.TotalDays); 
            decimal finePerDay = 5m; 
            decimal totalFine = lateDays * finePerDay;

            Console.WriteLine($"[{Renter.FirstName} {Renter.LastName}] Ended rental {lateDays} after deadline, fine: {totalFine} PLN");
        }
        else
        {
            Console.WriteLine($"[{Renter.FirstName} {Renter.LastName}] Ended rental before deadline");
        }

        RealRentalEnd = now;
        RentedDevice.IsAvailable = true;
        Renter.NumberOfDevicesRenter--;
        
        AllRentals.Remove(this);
    }

    public static void DisplayRentalsForPerson(Person person)
    {
        var rentals = AllRentals.Where(rental =>
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
    
    public static void DisplayRentalsAfterDeadline()
    {
        var rentalsAfterDeadline = AllRentals.Where(rental => DateTime.Now > rental.RentalEnd);
        
        Console.WriteLine();
        Console.WriteLine("Rentals after deadline: ");
        foreach (var rental in rentalsAfterDeadline)
        {
            Console.WriteLine(rental);
        }
    }

    public override string ToString()
    {
        return $"[{Renter.FirstName} {Renter.LastName}] Active rental with ID {Id} ({RentedDevice.GetType().Name}) end deadline at {RentalEnd:yyyy-MM-dd HH:mm}";
    }
}
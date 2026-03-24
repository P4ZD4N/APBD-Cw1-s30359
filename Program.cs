using APBD_Cw1_s30359.Exceptions;
using APBD_Cw1_s30359.Exceptions.Device;
using APBD_Cw1_s30359.Models.Devices;
using APBD_Cw1_s30359.Models.Users;
using APBD_Cw1_s30359.Services;
using APBD_Cw1_s30359.Services.DeviceServices;
using APBD_Cw1_s30359.Services.RentalServices;
using APBD_Cw1_s30359.Services.ReportServices;

IDeviceService deviceService = new DeviceService();
IRentalService rentalService = new RentalService();
IReportService reportService = new ReportService();

// 11. Devices
var camera1 = new Camera("Canon", "EOS 250D", 2021, "CAM001", 24, true);
var laptop1 = new Laptop("Dell", "XPS 13", 2022, "LAP001", 16, true);
var projector1 = new Projector("Epson", "EB-X41", 2021, "PROJ001", 3600, true);
var projector2 = new Projector("BenQ", "MH550", 2020, "PROJ002", 3500, false);

// 12. Users
var employee1 = new Employee("Jan", "Kowalski", new DateOnly(1980, 5, 12));
var employee2 = new Employee("Anna", "Nowak", new DateOnly(1975, 11, 3));

var student1 = new Student("Piotr", "Wiśniewski", new DateOnly(2002, 3, 15));
var student2 = new Student("Katarzyna", "Wójcik", new DateOnly(2001, 7, 22));
var student3 = new Student("Michał", "Kamiński", new DateOnly(2003, 1, 10));

// 13. Valid rental
ValidRental();

// 14. Invalid rental (camera1 is already rented by student1)
InvalidRentalAlreadyRented();
    
// 14. Invalid rental (trying to exceed student limit)
InvalidRentalExceedingLimit();

// 15. End of rental before deadline
EndRentalBeforeDeadline();

// 16. End of rental 2 days after deadline (fine for 2 days)
EndRentalAfterDeadline();

// Displaying all devices with status
deviceService.DisplayAllDevicesWithStatus();

// Displaying available devices
deviceService.DisplayAvailableDevices();

// Displaying rentals for student1
rentalService.DisplayRentalsForPerson(employee1);

// Displaying rentals after deadline
rentalService.DisplayRentalsAfterDeadline();

// Displaying report about current state
reportService.DisplayReportAboutCurrentState();

void ValidRental()
{
    rentalService.StartRental(
        student1, 
        camera1, 
        new DateTime(2026, 03, 17, 9, 30, 0), 
        DateTime.Now.AddDays(1));
}

void InvalidRentalAlreadyRented()
{
    try
    {
        rentalService.StartRental(
            student2,
            camera1,
            new DateTime(2026, 03, 18, 9, 30, 0),
            new DateTime(2026, 03, 20, 9, 30, 0));
    }
    catch (DeviceAlreadyRentedException exception)
    {
        Console.WriteLine("Error message: " + exception.Message);
    }
}

void InvalidRentalExceedingLimit()
{
    try
    {
        rentalService.StartRental(
            student1,
            projector1,
            new DateTime(2026, 03, 18, 9, 30, 0),
            new DateTime(2026, 03, 20, 9, 30, 0));
        rentalService.StartRental(
            student1,
            projector2,
            new DateTime(2026, 03, 18, 9, 30, 0),
            new DateTime(2026, 03, 20, 9, 30, 0));
    }
    catch (RentalMaximumExceededException exception)
    {
        Console.WriteLine("Error message: " + exception.Message);
    }
}

void EndRentalBeforeDeadline()
{
    rentalService.EndRental(1);
}

void EndRentalAfterDeadline()
{
    rentalService.StartRental(
        employee1, 
        laptop1, 
        DateTime.Now.AddDays(-5), 
        DateTime.Now.AddDays(-2).AddHours(1));
    rentalService.EndRental(2);
}
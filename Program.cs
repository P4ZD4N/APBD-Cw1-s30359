using APBD_Cw1_s30359.Models.Devices;
using APBD_Cw1_s30359.models.rentals;
using APBD_Cw1_s30359.Models.Users;
using APBD_Cw1_s30359.Services;

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
var rental1 = new Rental(student1, camera1, new DateTime(2026, 03, 17, 9, 30, 0), DateTime.Now.AddDays(1));

// 14. Invalid rental (camera1 is already rented by student1)
// var rental2 = new Rental(student2, camera1, new DateTime(2026, 03, 18, 9, 30, 0), new DateTime(2026, 03, 20, 9, 30, 0));

// 14. Invalid rental (trying to exceed student limit)

var rental3 = new Rental(student1, projector1, new DateTime(2026, 03, 18, 9, 30, 0), new DateTime(2026, 03, 20, 9, 30, 0));
// var rental4 = new Rental(student1, projector2,  new DateTime(2026, 03, 18, 9, 30, 0), new DateTime(2026, 03, 20, 9, 30, 0));

// 15. End of rental before deadline
rental1.End();

// 16. End of rental 2 days after deadline (fine for 2 days)
var rental5 = new Rental(employee1, laptop1, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-2).AddHours(1));
rental5.End();

// Displaying all devices with status
Device.DisplayAllDevicesWithStatus();

// Displaying available devices
Device.DisplayAvailableDevices();

// Displaying rentals for student1
Rental.DisplayRentalsForPerson(student1);


// Displaying rentals after deadline
Rental.DisplayRentalsAfterDeadline();

// Displaying report about current state
ReportService.DisplayReportAboutCurrentState();
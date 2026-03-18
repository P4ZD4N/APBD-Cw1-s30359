using APBD_Cw1_s30359.Enums;
using APBD_Cw1_s30359.Models.Devices;
using APBD_Cw1_s30359.Models.Users;

var employee1 = new Employee("Jan", "Kowalski", new DateOnly(1980, 5, 12), UserType.Employee);
var employee2 = new Employee("Anna", "Nowak", new DateOnly(1975, 11, 3), UserType.Employee);

var student1 = new Student("Piotr", "Wiśniewski", new DateOnly(2002, 3, 15), UserType.Student);
var student2 = new Student("Katarzyna", "Wójcik", new DateOnly(2001, 7, 22), UserType.Student);
var student3 = new Student("Michał", "Kamiński", new DateOnly(2003, 1, 10), UserType.Student);

var camera1 = new Camera("Canon", "EOS 250D", 2021, "CAM001", 24, true);
var camera2 = new Camera("Nikon", "D3500", 2020, "CAM002", 24, true);
var camera3 = new Camera("Sony", "Alpha a6400", 2022, "CAM003", 24, false);

var laptop1 = new Laptop("Dell", "XPS 13", 2022, "LAP001", 16, true);
var laptop2 = new Laptop("Lenovo", "ThinkPad E14", 2021, "LAP002", 8, false);
var laptop3 = new Laptop("Apple", "MacBook Air M1", 2020, "LAP003", 8, false);

var projector1 = new Projector("Epson", "EB-X41", 2021, "PROJ001", 3600, true);
var projector2 = new Projector("BenQ", "MH550", 2020, "PROJ002", 3500, false);
var projector3 = new Projector("ViewSonic", "PA503S", 2022, "PROJ003", 3800, true);

Device.DisplayAllDevicesWithStatus();
Console.WriteLine();
Device.DisplayAvailableDevices();
Console.WriteLine();

camera1.Rent(student1, new DateTime(2026, 03, 18), new DateTime(2026, 03, 20));
laptop1.Rent(student1, new DateTime(2026, 03, 18), new DateTime(2026, 03, 20));
projector1.Rent(student1, new DateTime(2026, 03, 18), new DateTime(2026, 03, 20));

Console.WriteLine();
Device.DisplayAvailableDevices();
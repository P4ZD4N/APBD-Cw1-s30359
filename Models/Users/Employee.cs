using APBD_Cw1_s30359.Enums;

namespace APBD_Cw1_s30359.Models.Users;

public class Employee : Person {

    public int Id { get; }
        
    private static int _employeeCount = 1;

    public Employee(string firstName, string lastName, DateOnly birthDate, UserType userType) 
        : base(firstName, lastName, birthDate, userType)
    {
        Id = _employeeCount;
        _employeeCount++;
    }
}
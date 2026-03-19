namespace APBD_Cw1_s30359.Models.Users;

public class Employee : Person {

    public int Id { get; }
        
    private static int _employeeCount = 1;

    public Employee(string firstName, string lastName, DateOnly birthDate) 
        : base(firstName, lastName, birthDate)
    {
        Id = _employeeCount;
        _employeeCount++;
    }
}
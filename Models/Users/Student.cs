using APBD_Cw1_s30359.Enums;

namespace APBD_Cw1_s30359.Models.Users;

public class Student : Person
{
    public int Id { get; }
        
    private static int _studentCount = 1;

    public Student(string firstName, string lastName, DateOnly birthDate, UserType userType) 
        : base(firstName, lastName, birthDate, userType)
    {
        Id = _studentCount;
        _studentCount++;
    }
}
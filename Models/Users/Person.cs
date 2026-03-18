using APBD_Cw1_s30359.Enums;

namespace APBD_Cw1_s30359.Models.Users;

public abstract class Person(string firstName, string lastName, DateOnly birthDate, UserType userType)
{
    public string FirstName = firstName;
    public string LastName = lastName;
    public DateOnly BirthDate = birthDate;
    public UserType UserType = userType;
}
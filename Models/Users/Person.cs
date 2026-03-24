namespace APBD_Cw1_s30359.Models.Users;

public abstract class Person(string firstName, string lastName, DateOnly birthDate)
{
    public readonly string FirstName = firstName;
    public readonly string LastName = lastName;
    public DateOnly BirthDate = birthDate;
    public int NumberOfDevicesRenter = 0;
    
    public abstract int GetRentalLimit();
}
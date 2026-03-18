namespace APBD_Cw1_s30359.Models.Users;

public abstract class Person(string firstName, string lastName, DateOnly birthDate)
{
    public string FirstName = firstName;
    public string LastName = lastName;
    public DateOnly BirthDate = birthDate;
}
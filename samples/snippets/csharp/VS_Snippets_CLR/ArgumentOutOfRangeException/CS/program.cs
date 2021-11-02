// <Snippet1>
using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Guest guest1 = new Guest("Ben", "Miller", 17);
            Console.WriteLine(guest1.GuestInfo());
        }
        catch (ArgumentOutOfRangeException argumentOutOfRangeException)
        {
            Console.WriteLine("Error: {0}", argumentOutOfRangeException.Message);
        }
    }
}

class Guest
{
    private string firstName;
    private string lastName;
    private int age;

    public Guest(string firstName, string lastName, int age)
    {
        if (age < 21)
            throw new ArgumentOutOfRangeException(nameof(age), "All guests must be 21-years-old or older.");

        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public string GuestInfo()
    {
        string guestInfo = firstName + " " + lastName + ", " + age.ToString();
        return guestInfo;
    }
}
// </Snippet1>

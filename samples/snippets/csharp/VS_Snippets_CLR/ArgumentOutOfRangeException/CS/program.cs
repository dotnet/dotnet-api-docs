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
        catch (ArgumentOutOfRangeException outOfRange)
        {
            Console.WriteLine("Error: {0}", outOfRange.Message);
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
        this.firstName = firstName;
        this.lastName = lastName;
        if (age < 21)
            throw new ArgumentOutOfRangeException("age", "All guests must be 21-years-old or older.");
        else
            this.age = age;
    }

    public string GuestInfo()
    {
        string gInfo = firstName + " " + lastName + ", " + age.ToString();
        return gInfo;
    }
}
// </Snippet1>

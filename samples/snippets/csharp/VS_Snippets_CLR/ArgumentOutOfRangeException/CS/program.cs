// <Snippet1>
using System;
using static System.Console;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var guest1 = new Guest("Ben", "Miller", 17);
            WriteLine(guest1.GuestInfo);
        }
        catch (ArgumentOutOfRangeException argumentOutOfRangeException)
        {
            WriteLine($"Error: {argumentOutOfRangeException.Message}");
        }
    }
}

class Guest
{
    private const int minimumRequiredAge = 21;

    private string firstName;
    private string lastName;
    private int age;

    public Guest(string firstName, string lastName, int age)
    {
        if (age < minimumRequiredAge)
            throw new ArgumentOutOfRangeException(nameof(age), $"All guests must be {minimumRequiredAge}-years-old or older.");

        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public string GuestInfo => $"{firstName} {lastName}, {age}";
}
// </Snippet1>

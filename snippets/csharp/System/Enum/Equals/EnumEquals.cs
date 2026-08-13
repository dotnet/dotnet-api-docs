//<snippet1>
using System;

public class EqualsTest
{
    enum Colors { Red, Green, Blue, Yellow };
    enum Mammals { Cat, Dog, Horse, Dolphin };

    public static void Main()
    {
        Mammals myPet = Mammals.Cat;
        Colors myColor = Colors.Red;
        Mammals yourPet = Mammals.Dog;
        Colors yourColor = Colors.Red;

        Console.WriteLine($"My favorite animal is a {myPet}");
        Console.WriteLine($"Your favorite animal is a {yourPet}");
        Console.WriteLine($"Do we like the same animal? {(myPet.Equals(yourPet) ? "Yes" : "No")}");

        Console.WriteLine();
        Console.WriteLine($"My favorite color is {myColor}");
        Console.WriteLine($"Your favorite color is {yourColor}");
        Console.WriteLine($"Do we like the same color? {(myColor.Equals(yourColor) ? "Yes" : "No")}");

        Console.WriteLine();
        Console.WriteLine($"The value of my color ({myColor}) is {Enum.Format(typeof(Colors), myColor, "d")}");
        Console.WriteLine($"The value of my pet (a {myPet}) is {Enum.Format(typeof(Mammals), myPet, "d")}");
        Console.WriteLine($"Even though they have the same value, are they equal? {(myColor.Equals(myPet) ? "Yes" : "No")}");
    }
}
// The example displays the following output:
//    My favorite animal is a Cat
//    Your favorite animal is a Dog
//    Do we like the same animal? No
//
//    My favorite color is Red
//    Your favorite color is Red
//    Do we like the same color? Yes
//
//    The value of my color (Red) is 0
//    The value of my pet (a Cat) is 0
//    Even though they have the same value, are they equal? No
//</snippet1>

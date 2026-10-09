//<snippet1>
using System;

public class CompareToTest
{
    enum VehicleDoors { Motorbike = 0, Sportscar = 2, Sedan = 4, Hatchback = 5 };

    public static void Main()
    {
        VehicleDoors myVeh = VehicleDoors.Sportscar;
        VehicleDoors yourVeh = VehicleDoors.Motorbike;
        VehicleDoors otherVeh = VehicleDoors.Sedan;

        Console.WriteLine($"Does a {myVeh} have more doors than a {yourVeh}?");
        Console.WriteLine($"{(myVeh.CompareTo(yourVeh) > 0 ? "Yes" : "No")}{Environment.NewLine}");

        Console.WriteLine($"Does a {myVeh} have more doors than a {otherVeh}?");
        Console.WriteLine($"{(myVeh.CompareTo(otherVeh) > 0 ? "Yes" : "No")}");
    }
}
// The example displays the following output:
//       Does a Sportscar have more doors than a Motorbike?
//       Yes
//
//       Does a Sportscar have more doors than a Sedan?
//       No
//</snippet1>

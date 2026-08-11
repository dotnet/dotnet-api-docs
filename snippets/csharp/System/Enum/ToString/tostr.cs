//<snippet1>
// Sample for Enum.ToString(String)
using System;

class Sample
{
    enum Colors { Red, Green, Blue, Yellow = 12 };

    public static void Main()
    {
        Colors myColor = Colors.Yellow;

        Console.WriteLine($"Colors.Red = {Colors.Red.ToString("d")}");
        Console.WriteLine($"Colors.Green = {Colors.Green.ToString("d")}");
        Console.WriteLine($"Colors.Blue = {Colors.Blue.ToString("d")}");
        Console.WriteLine($"Colors.Yellow = {Colors.Yellow.ToString("d")}");

        Console.WriteLine("{0}myColor = Colors.Yellow{0}", Environment.NewLine);

        Console.WriteLine($"myColor.ToString(\"g\") = {myColor.ToString("g")}");
        Console.WriteLine($"myColor.ToString(\"G\") = {myColor.ToString("G")}");

        Console.WriteLine($"myColor.ToString(\"x\") = {myColor.ToString("x")}");
        Console.WriteLine($"myColor.ToString(\"X\") = {myColor.ToString("X")}");

        Console.WriteLine($"myColor.ToString(\"d\") = {myColor.ToString("d")}");
        Console.WriteLine($"myColor.ToString(\"D\") = {myColor.ToString("D")}");

        Console.WriteLine($"myColor.ToString(\"f\") = {myColor.ToString("f")}");
        Console.WriteLine($"myColor.ToString(\"F\") = {myColor.ToString("F")}");
    }
}
/*
This example produces the following results:
Colors.Red = 0
Colors.Green = 1
Colors.Blue = 2
Colors.Yellow = 12

myColor = Colors.Yellow

myColor.ToString("g") = Yellow
myColor.ToString("G") = Yellow
myColor.ToString("x") = 0000000C
myColor.ToString("X") = 0000000C
myColor.ToString("d") = 12
myColor.ToString("D") = 12
myColor.ToString("f") = Yellow
myColor.ToString("F") = Yellow
*/
//</snippet1>

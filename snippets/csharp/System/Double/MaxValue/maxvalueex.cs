// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        double result1 = 7.997e307 + 9.985e307;
        Console.WriteLine($"{result1} (Positive Infinity: {double.IsPositiveInfinity(result1)})");

        double result2 = 1.5935e250 * 7.948e110;
        Console.WriteLine($"{result2} (Positive Infinity: {double.IsPositiveInfinity(result2)})");

        double result3 = Math.Pow(1.256e100, 1.34e20);
        Console.WriteLine($"{result3} (Positive Infinity: {double.IsPositiveInfinity(result3)})");
    }
}
// The example displays the following output:
//    Infinity (Positive Infinity: True)
//    Infinity (Positive Infinity: True)
//    Infinity (Positive Infinity: True)
// </Snippet1>

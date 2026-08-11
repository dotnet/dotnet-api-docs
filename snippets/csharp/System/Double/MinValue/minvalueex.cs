// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        double result1 = -7.997e307 + -9.985e307;
        Console.WriteLine($"{result1} (Negative Infinity: {double.IsNegativeInfinity(result1)})");

        double result2 = -1.5935e250 * 7.948e110;
        Console.WriteLine($"{result2} (Negative Infinity: {double.IsNegativeInfinity(result2)})");
    }
}
// The example displays the following output:
//    -Infinity (Negative Infinity: True)
//    -Infinity (Negative Infinity: True)
// </Snippet1>

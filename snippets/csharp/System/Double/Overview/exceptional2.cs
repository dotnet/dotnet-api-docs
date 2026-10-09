// <Snippet2>
using System;

public class Example7
{
    public static void Main()
    {
        double value1 = 4.565e153;
        double value2 = 6.9375e172;
        double result = value1 * value2;
        Console.WriteLine($"PositiveInfinity: {double.IsPositiveInfinity(result)}");
        Console.WriteLine($"NegativeInfinity: {double.IsNegativeInfinity(result)}{Environment.NewLine}");

        value1 = -value1;
        result = value1 * value2;
        Console.WriteLine($"PositiveInfinity: {double.IsPositiveInfinity(result)}");
        Console.WriteLine($"NegativeInfinity: {double.IsNegativeInfinity(result)}");
    }
}

// The example displays the following output:
//       PositiveInfinity: True
//       NegativeInfinity: False
//
//       PositiveInfinity: False
//       NegativeInfinity: True
// </Snippet2>

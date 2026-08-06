// <Snippet1>
using System;

public class Example6
{
    public static void Main()
    {
        double value1 = 1.1632875981534209e-225;
        double value2 = 9.1642346778e-175;
        double result = value1 * value2;
        Console.WriteLine($"{value1} * {value2} = {result}");
        Console.WriteLine($"{result} = 0: {result.Equals(0.0)}");
    }
}
// The example displays the following output:
//       1.16328759815342E-225 * 9.1642346778E-175 = 0
//       0 = 0: True
// </Snippet1>

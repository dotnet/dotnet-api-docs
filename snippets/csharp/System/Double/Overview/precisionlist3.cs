// <Snippet6>
using System;

public class Example10
{
    public static void Main()
    {
        double[] values = { 10.0, 2.88, 2.88, 2.88, 9.0 };
        double result = 27.64;
        double total = 0;
        foreach (double value in values)
            total += value;

        if (total.Equals(result))
            Console.WriteLine("The sum of the values equals the total.");
        else
            Console.WriteLine($"The sum of the values ({total}) does not equal the total ({result}).");
    }
}
// The example displays the following output:
//      The sum of the values (36.64) does not equal the total (36.64).
//
// If the index items in the Console.WriteLine statement are changed to {0:R},
// the example displays the following output:
//       The sum of the values (27.639999999999997) does not equal the total (27.64).
// </Snippet6>

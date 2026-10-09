// <Snippet12>
using System;

class Example12
{
    public static void Main()
    {
        // Define a set of Decimal values.
        decimal[] values = { 1.45m, 1.55m, 123.456789m, 123.456789m,
                           123.456789m, -123.456m,
                           new decimal(1230000000, 0, 0, true, 7 ),
                           new decimal(1230000000, 0, 0, true, 7 ),
                           -9999999999.9999999999m,
                           -9999999999.9999999999m };
        // Define a set of integers to for decimals argument.
        int[] decimals = { 1, 1, 4, 6, 8, 0, 3, 11, 9, 10 };

        Console.WriteLine($"{"Argument",26}{"Digits",8}{"Result",26}");
        Console.WriteLine($"{"--------",26}{"------",8}{"------",26}");
        for (int ctr = 0; ctr < values.Length; ctr++)
            Console.WriteLine($"{values[ctr],26}{decimals[ctr],8}{decimal.Round(values[ctr], decimals[ctr]),26}");
    }
}
// The example displays the following output:
//                   Argument  Digits                    Result
//                   --------  ------                    ------
//                       1.45       1                       1.4
//                       1.55       1                       1.6
//                 123.456789       4                  123.4568
//                 123.456789       6                123.456789
//                 123.456789       8                123.456789
//                   -123.456       0                      -123
//               -123.0000000       3                  -123.000
//               -123.0000000      11              -123.0000000
//     -9999999999.9999999999       9    -10000000000.000000000
//     -9999999999.9999999999      10    -9999999999.9999999999
//</Snippet12>

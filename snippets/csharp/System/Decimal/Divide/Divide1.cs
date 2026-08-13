// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        // Divide a series of numbers by 22.1
        decimal dividend = 1230.0m;
        decimal divisor = 22.1m;
        for (int ctr = 0; ctr <= 10; ctr++)
        {
            Console.WriteLine($"{dividend:N1} / {divisor:N1} = {decimal.Divide(dividend, divisor):N4}");
            dividend += .1m;
        }
    }
}
// The example displays the following output:
//       1,230.0 / 22.1 = 55.6561
//       1,230.1 / 22.1 = 55.6606
//       1,230.2 / 22.1 = 55.6652
//       1,230.3 / 22.1 = 55.6697
//       1,230.4 / 22.1 = 55.6742
//       1,230.5 / 22.1 = 55.6787
//       1,230.6 / 22.1 = 55.6833
//       1,230.7 / 22.1 = 55.6878
//       1,230.8 / 22.1 = 55.6923
//       1,230.9 / 22.1 = 55.6968
//       1,231.0 / 22.1 = 55.7014
// </Snippet1>

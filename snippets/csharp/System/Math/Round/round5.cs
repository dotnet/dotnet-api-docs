// <Snippet4>
using System;

public class MathRoundExample4
{
    public static void Run()
    {
        double value = 11.1;
        for (int ctr = 0; ctr <= 5; ctr++)
            value = RoundValueAndAdd(value);

        Console.WriteLine();

        value = 11.5;
        RoundValueAndAdd(value);
    }

    private static double RoundValueAndAdd(double value)
    {
        Console.WriteLine($"{value} --> {Math.Round(value,
                          MidpointRounding.AwayFromZero)}");
        return value + .1;
    }
}
// The example displays the following output:
//       11.1 --> 11
//       11.2 --> 11
//       11.3 --> 11
//       11.4 --> 11
//       11.5 --> 11
//       11.6 --> 12
//
//       11.5 --> 12
// </Snippet4>

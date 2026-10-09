// <Snippet8>
using System;

public class Example2
{
    public static void Main()
    {
        // Instantiate the Boolean generator.
        BooleanGenerator boolGen = new();
        int totalTrue = 0, totalFalse = 0;

        // Generate 1,0000 random Booleans, and keep a running total.
        for (int ctr = 0; ctr < 1000000; ctr++)
        {
            bool value = boolGen.NextBoolean();
            if (value)
                totalTrue++;
            else
                totalFalse++;
        }
        Console.WriteLine($"Number of true values:  {totalTrue,7:N0} ({((double)totalTrue) / (totalTrue + totalFalse):P3})");
        Console.WriteLine($"Number of false values: {totalFalse,7:N0} ({((double)totalFalse) / (totalTrue + totalFalse):P3})");
    }
}

public class BooleanGenerator
{
    Random rnd;

    public BooleanGenerator() => rnd = new();

    public bool NextBoolean() => rnd.Next(0, 2) == 1;
}
// The example displays output like the following:
//       Number of true values:  500,004 (50.000 %)
//       Number of false values: 499,996 (50.000 %)
// </Snippet8>

// <Snippet3>
using System;
using System.Collections.Generic;

public class OutOfMemoryExceptionExample1
{
    public static void Run()
    {
        double[] values = GetData();
        // Compute mean.
        Console.WriteLine($"Sample mean: {GetMean(values)}, N = {values.Length}");
    }

    private static double[] GetData()
    {
        Random rnd = new();
        List<double> values = new();
        for (int ctr = 1; ctr <= 200000000; ctr++)
        {
            values.Add(rnd.NextDouble());
            if (ctr % 10000000 == 0)
                Console.WriteLine($"Retrieved {ctr:N0} items of data.");
        }
        return values.ToArray();
    }

    private static double GetMean(double[] values)
    {
        double sum = 0;
        foreach (double value in values)
            sum += value;

        return sum / values.Length;
    }
}
// The example displays output like the following:
//    Retrieved 10,000,000 items of data.
//    Retrieved 20,000,000 items of data.
//    Retrieved 30,000,000 items of data.
//    Retrieved 40,000,000 items of data.
//    Retrieved 50,000,000 items of data.
//    Retrieved 60,000,000 items of data.
//    Retrieved 70,000,000 items of data.
//    Retrieved 80,000,000 items of data.
//    Retrieved 90,000,000 items of data.
//    Retrieved 100,000,000 items of data.
//    Retrieved 110,000,000 items of data.
//    Retrieved 120,000,000 items of data.
//    Retrieved 130,000,000 items of data.
//
//    Unhandled Exception: OutOfMemoryException.
// </Snippet3>

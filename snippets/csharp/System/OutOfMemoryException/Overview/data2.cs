// <Snippet4>
using System;


public class Example
{
    public static void Main()
    {
        Tuple<double, long> result = GetResult();
        Console.WriteLine($"Sample mean: {result.Item1}, N = {result.Item2:N0}");
    }

    private static Tuple<double, long> GetResult()
    {
        int chunkSize = 50000000;
        int nToGet = 200000000;
        Random rnd = new();
        // FileStream fs = new FileStream(@".\data.bin", FileMode.Create);
        // BinaryWriter bin = new BinaryWriter(fs);
        // bin.Write((int)0);
        int n = 0;
        double sum = 0;
        for (int outer = 0;
             outer <= ((int)Math.Ceiling(nToGet * 1.0 / chunkSize) - 1);
             outer++)
        {
            for (int inner = 0;
                 inner <= Math.Min(nToGet - n - 1, chunkSize - 1);
                 inner++)
            {
                double value = rnd.NextDouble();
                sum += value;
                n++;
                // bin.Write(value);
            }
        }
        // bin.Seek(0, SeekOrigin.Begin);
        // bin.Write(n);
        // bin.Close();
        return new Tuple<double, long>(sum / n, n);
    }
}
// The example displays output like the following:
//    Sample mean: 0.500022771458399, N = 200,000,000
// </Snippet4>

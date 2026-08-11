// <Snippet7>
using System;

public class ForeachExample1
{
    public static void Run()
    {
        // Generate array of random values.
        int[] values = PopulateArray(5, 10);
        // Display each element in the array.
        foreach (int value in values)
            Console.Write($"{values[value]}   ");
    }

    private static int[] PopulateArray(int items, int maxValue)
    {
        int[] values = new int[items];
        Random rnd = new();
        for (int ctr = 0; ctr < items; ctr++)
            values[ctr] = rnd.Next(0, maxValue + 1);

        return values;
    }
}
// The example displays output like the following:
//    6   4   4
//    Unhandled Exception: System.IndexOutOfRangeException:
//    Index was outside the bounds of the array.
//       at Example.Main()
// </Snippet7>

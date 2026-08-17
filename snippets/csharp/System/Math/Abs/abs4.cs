using System;

public class MathAbsExample4
{
    public static void Run()
    {
        // <Snippet4>
        int[] values = { int.MaxValue, 16921, 0, -804128, int.MinValue };
        foreach (int value in values)
        {
            try
            {
                Console.WriteLine($"Abs({value}) = {Math.Abs(value)}");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Unable to calculate the absolute value of {value}.");
            }
        }

        // The example displays the following output:
        //       Abs(2147483647) = 2147483647
        //       Abs(16921) = 16921
        //       Abs(0) = 0
        //       Abs(-804128) = 804128
        //       Unable to calculate the absolute value of -2147483648.
        // </Snippet4>
    }
}

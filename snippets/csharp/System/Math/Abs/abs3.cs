using System;

public class MathAbsExample3
{
    public static void Run()
    {
        // <Snippet3>
        short[] values = { short.MaxValue, 10328, 0, -1476, short.MinValue };
        foreach (short value in values)
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
        //       Abs(32767) = 32767
        //       Abs(10328) = 10328
        //       Abs(0) = 0
        //       Abs(-1476) = 1476
        //       Unable to calculate the absolute value of -32768.
        // </Snippet3>
    }
}

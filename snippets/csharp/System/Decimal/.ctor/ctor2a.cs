// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        decimal[] values = { 1234.96m, -1234.96m };
        foreach (decimal value in values)
        {
            int[] parts = decimal.GetBits(value);
            bool sign = (parts[3] & 0x80000000) != 0;

            byte scale = (byte)((parts[3] >> 16) & 0x7F);
            decimal newValue = new(parts[0], parts[1], parts[2], sign, scale);
            Console.WriteLine($"{value} --> {newValue}");
        }
    }
}
// The example displays the following output:
//       1234.96 --> 1234.96
//       -1234.96 --> -1234.96
// </Snippet1>

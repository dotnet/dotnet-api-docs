// <Snippet1>
using System;

class Example
{
    public static void Main()
    {
        decimal[] values = { 123m, new decimal(123000, 0, 0, false, 3),
                           123.999m, 65535.999m, 65536m,
                           32767.999m, 32768m, -0.999m,
                           -1m,  -32768.999m, -32769m };

        foreach (decimal value in values)
        {
            try
            {
                ushort number = decimal.ToUInt16(value);
                Console.WriteLine($"{value} --> {number}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"{e.GetType().Name}: {value}");
            }
        }
    }
}
// The example displays the following output:
//     123 --> 123
//     123.000 --> 123
//     123.999 --> 123
//     65535.999 --> 65535
//     OverflowException: 65536
//     32767.999 --> 32767
//     32768 --> 32768
//     -0.999 --> 0
//     OverflowException: -1
//     OverflowException: -32768.999
//     OverflowException: -32769
// </Snippet1>

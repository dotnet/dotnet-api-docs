// <Snippet2>
using System;

class Example
{
    public static void Main()
    {
        // Define an array of 32-bit unsigned integer values.
        uint[] values = { uint.MinValue, uint.MaxValue, 0xFFFFFF,
                          123456789, 4000000000 };
        // Convert each value to a Decimal.
        foreach (uint value in values)
        {
            decimal decValue = value;
            Console.WriteLine($"{value} ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})");
        }
    }
}
// The example displays the following output:
//       0 (UInt32) --> 0 (Decimal)
//       4294967295 (UInt32) --> 4294967295 (Decimal)
//       16777215 (UInt32) --> 16777215 (Decimal)
//       123456789 (UInt32) --> 123456789 (Decimal)
//       4000000000 (UInt32) --> 4000000000 (Decimal)
// </Snippet2>

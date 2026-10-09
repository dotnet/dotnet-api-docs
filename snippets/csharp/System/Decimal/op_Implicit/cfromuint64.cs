// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        // Define an array of 64-bit unsigned integer values.
        ulong[] values = { ulong.MinValue, ulong.MaxValue,
                           0xFFFFFFFFFFFF, 123456789123456789,
                           1000000000000000 };
        // Convert each value to a Decimal.
        foreach (ulong value in values)
        {
            decimal decValue = value;
            Console.WriteLine($"{value} ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})");
        }
    }
}
// The example displays the following output:
//    0 (UInt64) --> 0 (Decimal)
//    18446744073709551615 (UInt64) --> 18446744073709551615 (Decimal)
//    281474976710655 (UInt64) --> 281474976710655 (Decimal)
//    123456789123456789 (UInt64) --> 123456789123456789 (Decimal)
//    1000000000000000 (UInt64) --> 1000000000000000 (Decimal)
// </Snippet1>

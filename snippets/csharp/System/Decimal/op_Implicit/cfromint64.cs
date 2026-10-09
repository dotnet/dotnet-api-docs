//<Snippet1>
using System;

class Example
{
    public static void Main()
    {
        // Define an array of 64-bit integer values.
        long[] values = { long.MinValue, long.MaxValue,
                          0xFFFFFFFFFFFF, 123456789123456789,
                          -1000000000000000 };
        // Convert each value to a Decimal.
        foreach (long value in values)
        {
            decimal decValue = value;
            Console.WriteLine($"{value} ({value.GetType().Name}) --> {decValue} ({decValue.GetType().Name})");
        }
    }
}
// The example displays the following output:
//    -9223372036854775808 (Int64) --> -9223372036854775808 (Decimal)
//    9223372036854775807 (Int64) --> 9223372036854775807 (Decimal)
//    281474976710655 (Int64) --> 281474976710655 (Decimal)
//    123456789123456789 (Int64) --> 123456789123456789 (Decimal)
//    -1000000000000000 (Int64) --> -1000000000000000 (Decimal)
// </Snippet1>

using System;

public class Example4
{
    public static void Main()
    {
        // <Snippet20>
        dynamic[] values = { byte.MinValue, byte.MaxValue, decimal.MinValue,
                           decimal.MaxValue, short.MinValue, short.MaxValue,
                           int.MinValue, int.MaxValue, long.MinValue,
                           long.MaxValue, sbyte.MinValue, sbyte.MaxValue,
                           float.MinValue, float.MaxValue, ushort.MinValue,
                           ushort.MaxValue, uint.MinValue, uint.MaxValue,
                           ulong.MinValue, ulong.MaxValue };
        double dblValue;
        foreach (dynamic value in values)
        {
            if (value.GetType() == typeof(decimal))
                dblValue = (double)value;
            else
                dblValue = value;
            Console.WriteLine($"{value} ({value.GetType().Name}) --> " +
                $"{dblValue:R} ({dblValue.GetType().Name})");
        }

        // The example displays the following output:
        //    0 (Byte) --> 0 (Double)
        //    255 (Byte) --> 255 (Double)
        //    -79228162514264337593543950335 (Decimal) --> -7.9228162514264338E+28 (Double)
        //    79228162514264337593543950335 (Decimal) --> 7.9228162514264338E+28 (Double)
        //    -32768 (Int16) --> -32768 (Double)
        //    32767 (Int16) --> 32767 (Double)
        //    -2147483648 (Int32) --> -2147483648 (Double)
        //    2147483647 (Int32) --> 2147483647 (Double)
        //    -9223372036854775808 (Int64) --> -9.2233720368547758E+18 (Double)
        //    9223372036854775807 (Int64) --> 9.2233720368547758E+18 (Double)
        //    -128 (SByte) --> -128 (Double)
        //    127 (SByte) --> 127 (Double)
        //    -3.402823E+38 (Single) --> -3.4028234663852886E+38 (Double)
        //    3.402823E+38 (Single) --> 3.4028234663852886E+38 (Double)
        //    0 (UInt16) --> 0 (Double)
        //    65535 (UInt16) --> 65535 (Double)
        //    0 (UInt32) --> 0 (Double)
        //    4294967295 (UInt32) --> 4294967295 (Double)
        //    0 (UInt64) --> 0 (Double)
        //    18446744073709551615 (UInt64) --> 1.8446744073709552E+19 (Double)
        // </Snippet20>
    }
}

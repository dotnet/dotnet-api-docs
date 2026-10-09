// <Snippet1>
using System;

public class Example
{
    static int value = 112;

    public static void Main()
    {
        byte byte1 = 112;
        Console.WriteLine($"value = byte1: {value.Equals(byte1),15}");
        TestObjectForEquality(byte1);

        short short1 = 112;
        Console.WriteLine($"value = short1: {value.Equals(short1),15}");
        TestObjectForEquality(short1);

        long long1 = 112;
        Console.WriteLine($"value = long1: {value.Equals(long1),17}");
        TestObjectForEquality(long1);

        sbyte sbyte1 = 112;
        Console.WriteLine($"value = sbyte1: {value.Equals(sbyte1),15}");
        TestObjectForEquality(sbyte1);

        ushort ushort1 = 112;
        Console.WriteLine($"value = ushort1: {value.Equals(ushort1),15}");
        TestObjectForEquality(ushort1);

        ulong ulong1 = 112;
        Console.WriteLine($"value = ulong1: {value.Equals(ulong1),17}");
        TestObjectForEquality(ulong1);

        decimal dec1 = 112m;
        Console.WriteLine($"value = dec1: {value.Equals(dec1),20}");
        TestObjectForEquality(dec1);

        double dbl1 = 112;
        Console.WriteLine($"value = dbl1: {value.Equals(dbl1),19}");
        TestObjectForEquality(dbl1);
    }

    private static void TestObjectForEquality(object obj) => Console.WriteLine($"{value} ({value.GetType().Name}) = {obj} ({obj.GetType().Name}): {value.Equals(obj)}\n");
}
// The example displays the following output:
//       value = byte1:            True
//       112 (Int32) = 112 (Byte): False
//
//       value = short1:            True
//       112 (Int32) = 112 (Int16): False
//
//       value = long1:             False
//       112 (Int32) = 112 (Int64): False
//
//       value = sbyte1:            True
//       112 (Int32) = 112 (SByte): False
//
//       value = ushort1:            True
//       112 (Int32) = 112 (UInt16): False
//
//       value = ulong1:             False
//       112 (Int32) = 112 (UInt64): False
//
//       value = dec1:                False
//       112 (Int32) = 112 (Decimal): False
//
//       value = dbl1:               False
//       112 (Int32) = 112 (Double): False
// </Snippet1>

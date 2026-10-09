// <Snippet2>
using System;

public class Example
{
    static decimal value = 112m;

    public static void Main()
    {
        byte byte1 = 112;
        Console.WriteLine($"value = byte1: {value.Equals(byte1),17}");
        TestObjectForEquality(byte1);

        short short1 = 112;
        Console.WriteLine($"value = short1: {value.Equals(short1),17}");
        TestObjectForEquality(short1);

        int int1 = 112;
        Console.WriteLine($"value = int1: {value.Equals(int1),19}");
        TestObjectForEquality(int1);

        long long1 = 112;
        Console.WriteLine($"value = long1: {value.Equals(long1),18}");
        TestObjectForEquality(long1);

        sbyte sbyte1 = 112;
        Console.WriteLine($"value = sbyte1: {value.Equals(sbyte1),17}");
        TestObjectForEquality(sbyte1);

        ushort ushort1 = 112;
        Console.WriteLine($"value = ushort1: {value.Equals(ushort1),17}");
        TestObjectForEquality(ushort1);

        uint uint1 = 112;
        Console.WriteLine($"value = uint1: {value.Equals(uint1),19}");
        TestObjectForEquality(uint1);

        ulong ulong1 = 112;
        Console.WriteLine($"value = ulong1: {value.Equals(ulong1),18}");
        TestObjectForEquality(ulong1);

        float sng1 = 112;
        Console.WriteLine($"value = sng1: {value.Equals(sng1),21}");
        TestObjectForEquality(sng1);

        double dbl1 = 112;
        Console.WriteLine($"value = dbl1: {value.Equals(dbl1),21}");
        TestObjectForEquality(dbl1);
    }

    private static void TestObjectForEquality(object obj) => Console.WriteLine($"{value} ({value.GetType().Name}) = {obj} ({obj.GetType().Name}): {value.Equals(obj)}\n");
}
// The example displays the following output:
//       value = byte1:              True
//       112 (Decimal) = 112 (Byte): False
//
//       value = short1:              True
//       112 (Decimal) = 112 (Int16): False
//
//       value = int1:                True
//       112 (Decimal) = 112 (Int32): False
//
//       value = long1:               True
//       112 (Decimal) = 112 (Int64): False
//
//       value = sbyte1:              True
//       112 (Decimal) = 112 (SByte): False
//
//       value = ushort1:              True
//       112 (Decimal) = 112 (UInt16): False
//
//       value = uint1:                True
//       112 (Decimal) = 112 (UInt32): False
//
//       value = ulong1:               True
//       112 (Decimal) = 112 (UInt64): False
//
//       value = sng1:                 False
//       112 (Decimal) = 112 (Single): False
//
//       value = dbl1:                 False
//       112 (Decimal) = 112 (Double): False
// </Snippet2>

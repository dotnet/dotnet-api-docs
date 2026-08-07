// <Snippet1>
using System;

public class Example
{
    static short value = 112;

    public static void Main()
    {
        byte byte1 = 112;
        Console.WriteLine($"value = byte1: {value.Equals(byte1),15}");
        TestObjectForEquality(byte1);

        int int1 = 112;
        Console.WriteLine($"value = int1: {value.Equals(int1),17}");
        TestObjectForEquality(int1);

        sbyte sbyte1 = 112;
        Console.WriteLine($"value = sbyte1: {value.Equals(sbyte1),15}");
        TestObjectForEquality(sbyte1);

        ushort ushort1 = 112;
        Console.WriteLine($"value = ushort1: {value.Equals(ushort1),15}");
        TestObjectForEquality(ushort1);

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
//       112 (Int16) = 112 (Byte): False
//
//       value = int1:             False
//       112 (Int16) = 112 (Int32): False
//
//       value = sbyte1:            True
//       112 (Int16) = 112 (SByte): False
//
//       value = ushort1:            False
//       112 (Int16) = 112 (UInt16): False
//
//       value = dec1:                False
//       112 (Int16) = 112 (Decimal): False
//
//       value = dbl1:               False
//       112 (Int16) = 112 (Double): False
// </Snippet1>

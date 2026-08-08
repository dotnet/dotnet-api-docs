//<Snippet2>
using System;

class Example
{
    public static void Main()
    {
        // Define an array of integers.
        int[] values = { 0, 15, -15, 0x100000,  -0x100000, 1000000000,
                         -1000000000, int.MinValue, int.MaxValue };

        // Convert each integer to a byte array.
        Console.WriteLine($"{"Integer",16}{"Endian",10}{"Byte Array",17}");
        Console.WriteLine($"{"---",16}{"------",10}{"----------",17}");
        foreach (int value in values)
        {
            byte[] byteArray = BitConverter.GetBytes(value);
            Console.WriteLine($"{value,16}{(BitConverter.IsLittleEndian ? "Little" : " Big"),10}{BitConverter.ToString(byteArray),17}");
        }
    }
}
// This example displays output like the following:
//              Integer    Endian       Byte Array
//                  ---    ------       ----------
//                    0    Little      00-00-00-00
//                   15    Little      0F-00-00-00
//                  -15    Little      F1-FF-FF-FF
//              1048576    Little      00-00-10-00
//             -1048576    Little      00-00-F0-FF
//           1000000000    Little      00-CA-9A-3B
//          -1000000000    Little      00-36-65-C4
//          -2147483648    Little      00-00-00-80
//           2147483647    Little      FF-FF-FF-7F
//</Snippet2>

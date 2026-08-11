// <Snippet6>
using System;

public class Example1
{
    public static void Main()
    {
        double[] values = { 0.0, double.Epsilon };
        foreach (double value in values)
        {
            Console.WriteLine(GetComponentParts(value));
            Console.WriteLine();
        }
    }

    private static string GetComponentParts(double value)
    {
        string result = $"{value:R}: ";
        int indent = result.Length;

        // Convert the double to an 8-byte array.
        byte[] bytes = BitConverter.GetBytes(value);
        // Get the sign bit (byte 7, bit 7).
        result += $"Sign: {((bytes[7] & 0x80) == 0x80 ? "1 (-)" : "0 (+)")}\n";

        // Get the exponent (byte 6 bits 4-7 to byte 7, bits 0-6)
        int exponent = (bytes[7] & 0x07F) << 4;
        exponent = exponent | ((bytes[6] & 0xF0) >> 4);
        int adjustment = exponent != 0 ? 1023 : 1022;
        result += string.Format("{0}Exponent: 0x{1:X4} ({1})\n", new string(' ', indent), exponent - adjustment);

        // Get the significand (bits 0-51)
        long significand = ((bytes[6] & 0x0F) << 48);
        significand = significand | ((long)bytes[5] << 40);
        significand = significand | ((long)bytes[4] << 32);
        significand = significand | ((long)bytes[3] << 24);
        significand = significand | ((long)bytes[2] << 16);
        significand = significand | ((long)bytes[1] << 8);
        significand = significand | bytes[0];
        result += $"{new string(' ', indent)}Mantissa: 0x{significand:X13}\n";

        return result;
    }
}
//       // The example displays the following output:
//       0: Sign: 0 (+)
//          Exponent: 0xFFFFFC02 (-1022)
//          Mantissa: 0x0000000000000
//
//
//       4.94065645841247E-324: Sign: 0 (+)
//                              Exponent: 0xFFFFFC02 (-1022)
//                              Mantissa: 0x0000000000001
// </Snippet6>

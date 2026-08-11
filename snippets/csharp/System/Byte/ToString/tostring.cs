//<Snippet1>
// Example for the Byte.ToString( ) methods.
using System;
using System.Globalization;

class ByteToStringDemo
{
    static void RunToStringDemo()
    {
        byte smallValue = 13;
        byte largeValue = 234;

        // Format the Byte values without and with format strings.
        Console.WriteLine("\nIFormatProvider is not used:");
        Console.WriteLine($"   {"No format string:",-20}{smallValue.ToString(),10}{largeValue.ToString(),10}");
        Console.WriteLine($"   {"'X2' format string:",-20}{smallValue.ToString("X2"),10}{largeValue.ToString("X2"),10}");

        // Get the NumberFormatInfo object from the
        // invariant culture.
        CultureInfo culture = new("");
        NumberFormatInfo numInfo = culture.NumberFormat;

        // Set the digit grouping to 1, set the digit separator
        // to underscore, and set decimal digits to 0.
        numInfo.NumberGroupSizes = new int[] { 1 };
        numInfo.NumberGroupSeparator = "_";
        numInfo.NumberDecimalDigits = 0;

        // Use the NumberFormatInfo object for an IFormatProvider.
        Console.WriteLine(
            "\nA NumberFormatInfo object with digit group " +
            "size = 1 and \ndigit separator " +
            "= '_' is used for the IFormatProvider:");
        Console.WriteLine($"   {"No format string:",-20}{smallValue.ToString(numInfo),10}{largeValue.ToString(numInfo),10}");
        Console.WriteLine($"   {"'N' format string:",-20}{smallValue.ToString("N", numInfo),10}{largeValue.ToString("N", numInfo),10}");
    }

    static void Main()
    {
        Console.WriteLine("This example of\n" +
            "   Byte.ToString( ),\n" +
            "   Byte.ToString( String ),\n" +
            "   Byte.ToString( IFormatProvider ), and\n" +
            "   Byte.ToString( String, IFormatProvider )\n" +
            "generates the following output when formatting " +
            "Byte values \nwith combinations of format " +
            "strings and IFormatProvider.");

        RunToStringDemo();
    }
}

/*
This example of
   Byte.ToString( ),
   Byte.ToString( String ),
   Byte.ToString( IFormatProvider ), and
   Byte.ToString( String, IFormatProvider )
generates the following output when formatting Byte values
with combinations of format strings and IFormatProvider.

IFormatProvider is not used:
   No format string:           13       234
   'X2' format string:         0D        EA

A NumberFormatInfo object with digit group size = 1 and
digit separator = '_' is used for the IFormatProvider:
   No format string:           13       234
   'N' format string:         1_3     2_3_4
*/
//</Snippet1>

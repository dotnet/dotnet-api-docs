// <Snippet2>
using System;
using System.Globalization;

public class SByteParseStylesExample
{
    public static void Run()
    {
        NumberStyles style;
        sbyte number;

        // Parse value with no styles allowed.
        string[] values1 = [" 121 ", "121", "-121"];
        style = NumberStyles.None;
        Console.WriteLine($"Styles: {style}");
        foreach (string value in values1)
        {
            try
            {
                number = sbyte.Parse(value, style);
                Console.WriteLine($"   Converted '{value}' to {number}.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"   Unable to parse '{value}'.");
            }
        }
        Console.WriteLine();

        // Parse value with trailing sign.
        style = NumberStyles.Integer | NumberStyles.AllowTrailingSign;
        string[] values2 = [" 103+", " 103 +", "+103", "(103)", "   +103  "];
        Console.WriteLine($"Styles: {style}");
        foreach (string value in values2)
        {
            try
            {
                number = sbyte.Parse(value, style);
                Console.WriteLine($"   Converted '{value}' to {number}.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"   Unable to parse '{value}'.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"   '{value}' is out of range of the SByte type.");
            }
        }
        Console.WriteLine();
    }
}
// The example displays the following output:
//       Styles: None
//          Unable to parse ' 121 '.
//          Converted '121' to 121.
//          Unable to parse '-121'.
//
//       Styles: Integer, AllowTrailingSign
//          Converted ' 103+' to 103.
//          Converted ' 103 +' to 103.
//          Converted '+103' to 103.
//          Unable to parse '(103)'.
//          Converted '   +103  ' to 103.
// </Snippet2>

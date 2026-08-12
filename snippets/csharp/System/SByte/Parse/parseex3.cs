// <Snippet3>
using System;
using System.Globalization;

public class SByteParseProviderExample
{
    public static void Run()
    {
        NumberFormatInfo nf = new()
        {
            NegativeSign = "~"
        };

        string[] values = ["-103", "+12", "~16", "  1", "~255"];
        IFormatProvider[] providers = [nf, CultureInfo.InvariantCulture];

        foreach (IFormatProvider provider in providers)
        {
            Console.WriteLine($"Conversions using {((object)provider).GetType().Name}:");
            foreach (string value in values)
            {
                try
                {
                    Console.WriteLine($"   Converted '{value}' to {sbyte.Parse(value, provider)}.");
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
        }
    }
}
// The example displays the following output:
//       Conversions using NumberFormatInfo:
//          Unable to parse '-103'.
//          Converted '+12' to 12.
//          Converted '~16' to -16.
//          Converted '  1' to 1.
//          '~255' is out of range of the SByte type.
//       Conversions using CultureInfo:
//          Converted '-103' to -103.
//          Converted '+12' to 12.
//          Unable to parse '~16'.
//          Converted '  1' to 1.
//          Unable to parse '~255'.
// </Snippet3>

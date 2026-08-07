// <Snippet4>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        string[] cultureNames = { "en-US", "fr-FR" };
        NumberStyles[] styles = { NumberStyles.Integer,
                               NumberStyles.Integer | NumberStyles.AllowDecimalPoint };
        string[] values = { "170209", "+170209.0", "+170209,0", "-103214.00",
                                 "-103214,00", "104561.1", "104561,1" };

        // Parse strings using each culture
        foreach (string cultureName in cultureNames)
        {
            CultureInfo ci = new(cultureName);
            Console.WriteLine($"Parsing strings using the {ci.DisplayName} culture");
            // Use each style.
            foreach (NumberStyles style in styles)
            {
                Console.WriteLine($"   Style: {style.ToString()}");
                // Parse each numeric string.
                foreach (string value in values)
                {
                    try
                    {
                        Console.WriteLine($"      Converted '{value}' to {ulong.Parse(value, style, ci)}.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"      Unable to parse '{value}'.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"      '{value}' is out of range of the UInt64 type.");
                    }
                }
            }
        }
    }
}
// The example displays the following output:
//       Style: Integer
//          Converted '170209' to 170209.
//          Unable to parse '+170209.0'.
//          Unable to parse '+170209,0'.
//          Unable to parse '-103214.00'.
//          Unable to parse '-103214,00'.
//          Unable to parse '104561.1'.
//          Unable to parse '104561,1'.
//       Style: Integer, AllowDecimalPoint
//          Converted '170209' to 170209.
//          Converted '+170209.0' to 170209.
//          Unable to parse '+170209,0'.
//          '-103214.00' is out of range of the UInt64 type.
//          Unable to parse '-103214,00'.
//          '104561.1' is out of range of the UInt64 type.
//          Unable to parse '104561,1'.
//    Parsing strings using the French (France) culture
//       Style: Integer
//          Converted '170209' to 170209.
//          Unable to parse '+170209.0'.
//          Unable to parse '+170209,0'.
//          Unable to parse '-103214.00'.
//          Unable to parse '-103214,00'.
//          Unable to parse '104561.1'.
//          Unable to parse '104561,1'.
//       Style: Integer, AllowDecimalPoint
//          Converted '170209' to 170209.
//          Unable to parse '+170209.0'.
//          Converted '+170209,0' to 170209.
//          Unable to parse '-103214.00'.
//          '-103214,00' is out of range of the UInt64 type.
//          Unable to parse '104561.1'.
//          '104561,1' is out of range of the UInt64 type.
// </Snippet4>

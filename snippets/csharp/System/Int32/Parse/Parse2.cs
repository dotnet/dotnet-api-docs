// <Snippet2>
using System;
using System.Globalization;

public class ParseInt32
{
    public static void Main()
    {
        Convert("104.0", NumberStyles.AllowDecimalPoint);
        Convert("104.9", NumberStyles.AllowDecimalPoint);
        Convert(" $17,198,064.42", NumberStyles.AllowCurrencySymbol |
                                   NumberStyles.Number);
        Convert("103E06", NumberStyles.AllowExponent);
        Convert("-1,345,791", NumberStyles.AllowThousands);
        Convert("(1,345,791)", NumberStyles.AllowThousands |
                               NumberStyles.AllowParentheses);
    }

    private static void Convert(string value, NumberStyles style)
    {
        try
        {
            int number = int.Parse(value, style);
            Console.WriteLine($"Converted '{value}' to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to convert '{value}'.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{value}' is out of range of the Int32 type.");
        }
    }
}
// The example displays the following output to the console:
//       Converted '104.0' to 104.
//       '104.9' is out of range of the Int32 type.
//       ' $17,198,064.42' is out of range of the Int32 type.
//       Converted '103E06' to 103000000.
//       Unable to convert '-1,345,791'.
//       Converted '(1,345,791)' to -1345791.
// </Snippet2>

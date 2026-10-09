using System;
using System.Globalization;

public class Class1
{
    public static void Main()
    {
        CallParse();
        Console.WriteLine("-----");
        CallParseWithStyles();
        Console.WriteLine("-----");
        CallParseWithStylesAndProvider();
    }

    private static void CallParse()
    {
        // <Snippet1>
        string value;
        decimal number;
        // Parse an integer with thousands separators.
        value = "16,523,421";
        number = decimal.Parse(value);
        Console.WriteLine($"'{value}' converted to {number}.");
        // Displays:
        //    '16,523,421' converted to 16523421.

        // Parse a floating point value with thousands separators
        value = "25,162.1378";
        number = decimal.Parse(value);
        Console.WriteLine($"'{value}' converted to {number}.");
        // Displays:
        //    '25,162.1378' converted to 25162.1378.

        // Parse a floating point number with US currency symbol.
        value = "$16,321,421.75";
        try
        {
            number = decimal.Parse(value);
            Console.WriteLine($"'{value}' converted to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value}'.");
        }
        // Displays:
        //    Unable to parse '$16,321,421.75'.

        // Parse a number in exponential notation
        value = "1.62345e-02";
        try
        {
            number = decimal.Parse(value);
            Console.WriteLine($"'{value}' converted to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value}'.");
        }
        // Displays:
        //    Unable to parse '1.62345e-02'.
        // </Snippet1>
    }

    private static void CallParseWithStyles()
    {
        // <Snippet2>
        string value;
        decimal number;
        NumberStyles style;

        // Parse string with a floating point value using NumberStyles.None.
        value = "8694.12";
        style = NumberStyles.None;
        try
        {
            number = decimal.Parse(value, style);
            Console.WriteLine($"'{value}' converted to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value}'.");
        }
        // Displays:
        //    Unable to parse '8694.12'.

        // Parse string with a floating point value and allow decimal point.
        style = NumberStyles.AllowDecimalPoint;
        number = decimal.Parse(value, style);
        Console.WriteLine($"'{value}' converted to {number}.");
        // Displays:
        //    '8694.12' converted to 8694.12.

        // Parse string with negative value in parentheses
        value = "(1,789.34)";
        style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands |
                NumberStyles.AllowParentheses;
        number = decimal.Parse(value, style);
        Console.WriteLine($"'{value}' converted to {number}.");
        // Displays:
        //    '(1,789.34)' converted to -1789.34.

        // Parse string using Number style
        value = " -17,623.49 ";
        style = NumberStyles.Number;
        number = decimal.Parse(value, style);
        Console.WriteLine($"'{value}' converted to {number}.");
        // Displays:
        //    ' -17,623.49 ' converted to -17623.49.
        // </Snippet2>
    }

    private static void CallParseWithStylesAndProvider()
    {
        // <Snippet3>
        string value;
        decimal number;
        NumberStyles style;
        CultureInfo provider;

        // Parse string using " " as the thousands separator
        // and "," as the decimal separator for fr-FR culture.
        value = "892 694,12";
        style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
        provider = new("fr-FR");

        number = decimal.Parse(value, style, provider);
        Console.WriteLine($"'{value}' converted to {number}.");
        // Displays:
        //    '892 694,12' converted to 892694.12.

        try
        {
            number = decimal.Parse(value, style, CultureInfo.InvariantCulture);
            Console.WriteLine($"'{value}' converted to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value}'.");
        }
        // Displays:
        //    Unable to parse '892 694,12'.

        // Parse string using "$" as the currency symbol for en-GB and
        // en-US cultures.
        value = "$6,032.51";
        style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        provider = new("en-GB");

        try
        {
            number = decimal.Parse(value, style, provider);
            Console.WriteLine($"'{value}' converted to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value}'.");
        }
        // Displays:
        //    Unable to parse '$6,032.51'.

        provider = new("en-US");
        number = decimal.Parse(value, style, provider);
        Console.WriteLine($"'{value}' converted to {number}.");
        // Displays:
        //    '$6,032.51' converted to 6032.51.
        // </Snippet3>
    }
}

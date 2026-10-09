using System;
using System.Globalization;

public class Class1
{
    public static void Main()
    {
        CallParse1();
        Console.WriteLine("-----");
        CallParse3();
        Console.WriteLine("-----");
        CallParse4();
    }

    private static void CallParse1()
    {
        // <Snippet1>
        string value;
        short number;

        value = " 12603 ";
        try
        {
            number = short.Parse(value);
            Console.WriteLine($"Converted '{value}' to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to convert '{value}' to a 16-bit signed integer.");
        }

        value = " 16,054";
        try
        {
            number = short.Parse(value);
            Console.WriteLine($"Converted '{value}' to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to convert '{value}' to a 16-bit signed integer.");
        }

        value = " -17264";
        try
        {
            number = short.Parse(value);
            Console.WriteLine($"Converted '{value}' to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to convert '{value}' to a 16-bit signed integer.");
        }
        // The example displays the following output to the console:
        //       Converted ' 12603 ' to 12603.
        //       Unable to convert ' 16,054' to a 16-bit signed integer.
        //       Converted ' -17264' to -17264.
        // </Snippet1>
    }

    private static void CallParse3()
    {
        // <Snippet3>
        string value;
        short number;
        NumberStyles style;
        CultureInfo provider;

        // Parse string using "." as the thousands separator
        // and " " as the decimal separator.
        value = "19 694,00";
        style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
        provider = new("fr-FR");

        number = short.Parse(value, style, provider);
        Console.WriteLine($"'{value}' converted to {number}.");
        // Displays:
        //    '19 694,00' converted to 19694.

        try
        {
            number = short.Parse(value, style, CultureInfo.InvariantCulture);
            Console.WriteLine($"'{value}' converted to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value}'.");
        }
        // Displays:
        //    Unable to parse '19 694,00'.

        // Parse string using "$" as the currency symbol for en_GB and
        // en-US cultures.
        value = "$6,032.00";
        style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        provider = new("en-GB");

        try
        {
            number = short.Parse(value, style, CultureInfo.InvariantCulture);
            Console.WriteLine($"'{value}' converted to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value}'.");
        }
        // Displays:
        //    Unable to parse '$6,032.00'.

        provider = new("en-US");
        number = short.Parse(value, style, provider);
        Console.WriteLine($"'{value}' converted to {number}.");
        // Displays:
        //    '$6,032.00' converted to 6032.
        // </Snippet3>
    }

    private static void CallParse4()
    {
        // <Snippet4>
        string stringToConvert;
        short number;

        stringToConvert = " 214 ";
        try
        {
            number = short.Parse(stringToConvert, CultureInfo.InvariantCulture);
            Console.WriteLine($"Converted '{stringToConvert}' to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{stringToConvert}'.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("'{0'} is out of range of the Int16 data type.",
                              stringToConvert);
        }

        stringToConvert = " + 214";
        try
        {
            number = short.Parse(stringToConvert, CultureInfo.InvariantCulture);
            Console.WriteLine($"Converted '{stringToConvert}' to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{stringToConvert}'.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("'{0'} is out of range of the Int16 data type.",
                              stringToConvert);
        }

        stringToConvert = " +214 ";
        try
        {
            number = short.Parse(stringToConvert, CultureInfo.InvariantCulture);
            Console.WriteLine($"Converted '{stringToConvert}' to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{stringToConvert}'.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("'{0'} is out of range of the Int16 data type.",
                              stringToConvert);
        }
        // The example displays the following output to the console:
        //       Converted ' 214 ' to 214.
        //       Unable to parse ' + 214'.
        //       Converted ' +214 ' to 214.
        // </Snippet4>
    }
}

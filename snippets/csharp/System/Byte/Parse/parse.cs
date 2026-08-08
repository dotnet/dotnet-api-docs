using System;
using System.Globalization;

public class Class1
{
    public static void Main()
    {
        CallParse1();
        Console.WriteLine();
        CallParse2();
        Console.WriteLine();
        CallParse3();
        Console.WriteLine();
        CallParse4();
    }

    private static void CallParse1()
    {
        // <Snippet1>
        string stringToConvert = " 162";
        byte byteValue;
        try
        {
            byteValue = byte.Parse(stringToConvert);
            Console.WriteLine($"Converted '{stringToConvert}' to {byteValue}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{stringToConvert}'.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{stringToConvert}' is greater than {byte.MaxValue} or less than {byte.MinValue}.");
        }
        // The example displays the following output to the console:
        //       Converted ' 162' to 162.
        // </Snippet1>
    }

    private static void CallParse2()
    {
        // <Snippet2>
        string stringToConvert;
        byte byteValue;

        stringToConvert = " 214 ";
        try
        {
            byteValue = byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
            Console.WriteLine($"Converted '{stringToConvert}' to {byteValue}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{stringToConvert}'.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{stringToConvert}' is greater than {byte.MaxValue} or less than {byte.MinValue}.");
        }

        stringToConvert = " + 214 ";
        try
        {
            byteValue = byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
            Console.WriteLine($"Converted '{stringToConvert}' to {byteValue}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{stringToConvert}'.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{stringToConvert}' is greater than {byte.MaxValue} or less than {byte.MinValue}.");
        }

        stringToConvert = " +214 ";
        try
        {
            byteValue = byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
            Console.WriteLine($"Converted '{stringToConvert}' to {byteValue}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{stringToConvert}'.");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{stringToConvert}' is greater than {byte.MaxValue} or less than {byte.MinValue}.");
        }
        // The example displays the following output to the console:
        //       Converted ' 214 ' to 214.
        //       Unable to parse ' + 214 '.
        //       Converted ' +214 ' to 214.
        // </Snippet2>
    }
    private static void CallParse3()
    {
        // <Snippet3>
        string value;
        NumberStyles style;
        byte number;

        // Parse value with no styles allowed.
        style = NumberStyles.None;
        value = " 241 ";
        try
        {
            number = byte.Parse(value, style);
            Console.WriteLine($"Converted '{value}' to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value}'.");
        }

        // Parse value with trailing sign.
        style = NumberStyles.Integer | NumberStyles.AllowTrailingSign;
        value = " 163+";
        number = byte.Parse(value, style);
        Console.WriteLine($"Converted '{value}' to {number}.");

        // Parse value with leading sign.
        value = "   +253  ";
        number = byte.Parse(value, style);
        Console.WriteLine($"Converted '{value}' to {number}.");
        // This example displays the following output to the console:
        //       Unable to parse ' 241 '.
        //       Converted ' 163+' to 163.
        //       Converted '   +253  ' to 253.
        // </Snippet3>
    }

    private static void CallParse4()
    {
        // <Snippet4>
        NumberStyles style;
        CultureInfo culture;
        string value;
        byte number;

        // Parse number with decimals.
        // NumberStyles.Float includes NumberStyles.AllowDecimalPoint.
        style = NumberStyles.Float;
        culture = CultureInfo.CreateSpecificCulture("fr-FR");
        value = "12,000";

        number = byte.Parse(value, style, culture);
        Console.WriteLine($"Converted '{value}' to {number}.");

        culture = CultureInfo.CreateSpecificCulture("en-GB");
        try
        {
            number = byte.Parse(value, style, culture);
            Console.WriteLine($"Converted '{value}' to {number}.");
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{value}'.");
        }

        value = "12.000";
        number = byte.Parse(value, style, culture);
        Console.WriteLine($"Converted '{value}' to {number}.");
        // The example displays the following output to the console:
        //       Converted '12,000' to 12.
        //       Unable to parse '12,000'.
        //       Converted '12.000' to 12.
        // </Snippet4>
    }
}

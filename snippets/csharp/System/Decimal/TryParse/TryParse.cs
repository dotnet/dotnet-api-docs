using System;
using System.Globalization;

public class Class1
{
    public static void Main()
    {
        CallTryParse1();
        Console.WriteLine("----------");
        CallTryParse2();
    }

    private static void CallTryParse1()
    {
        // <Snippet1>
        string value;
        decimal number;

        // Parse a floating-point value with a thousands separator.
        value = "1,643.57";
        if (decimal.TryParse(value, out number))
            Console.WriteLine(number);
        else
            Console.WriteLine($"Unable to parse '{value}'.");

        // Parse a floating-point value with a currency symbol and a
        // thousands separator.
        value = "$1,643.57";
        if (decimal.TryParse(value, out number))
            Console.WriteLine(number);
        else
            Console.WriteLine($"Unable to parse '{value}'.");

        // Parse value in exponential notation.
        value = "-1.643e6";
        if (decimal.TryParse(value, out number))
            Console.WriteLine(number);
        else
            Console.WriteLine($"Unable to parse '{value}'.");

        // Parse a negative integer value.
        value = "-1689346178821";
        if (decimal.TryParse(value, out number))
            Console.WriteLine(number);
        else
            Console.WriteLine($"Unable to parse '{value}'.");
        // The example displays the following output to the console:
        //       1643.57
        //       Unable to parse '$1,643.57'.
        //       Unable to parse '-1.643e6'.
        //       -1689346178821
        // </Snippet1>
    }

    private static void CallTryParse2()
    {
        // <Snippet2>
        string value;
        NumberStyles style;
        CultureInfo culture;
        decimal number;

        // Parse currency value using en-GB culture.
        value = "£1,097.63";
        style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        culture = CultureInfo.CreateSpecificCulture("en-GB");
        if (decimal.TryParse(value, style, culture, out number))
            Console.WriteLine($"Converted '{value}' to {number}.");
        else
            Console.WriteLine($"Unable to convert '{value}'.");
        // Displays:
        //       Converted '£1,097.63' to 1097.63.

        value = "1345,978";
        style = NumberStyles.AllowDecimalPoint;
        culture = CultureInfo.CreateSpecificCulture("fr-FR");
        if (decimal.TryParse(value, style, culture, out number))
            Console.WriteLine($"Converted '{value}' to {number}.");
        else
            Console.WriteLine($"Unable to convert '{value}'.");
        // Displays:
        //       Converted '1345,978' to 1345.978.

        value = "1.345,978";
        style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
        culture = CultureInfo.CreateSpecificCulture("es-ES");
        if (decimal.TryParse(value, style, culture, out number))
            Console.WriteLine($"Converted '{value}' to {number}.");
        else
            Console.WriteLine($"Unable to convert '{value}'.");
        // Displays:
        //       Converted '1.345,978' to 1345.978.

        value = "1 345,978";
        if (decimal.TryParse(value, style, culture, out number))
            Console.WriteLine($"Converted '{value}' to {number}.");
        else
            Console.WriteLine($"Unable to convert '{value}'.");
        // Displays:
        //       Unable to convert '1 345,978'.
        // </Snippet2>
    }
}

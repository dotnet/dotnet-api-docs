using System;

public class Class1
{
    public static void Main()
    {
        DefaultTryParse();
        Console.WriteLine("----------");
        TryParseWithConstraints();
    }

    private static void DefaultTryParse()
    {
        // <Snippet1>
        string value;
        float number;

        // Parse a floating-point value with a thousands separator.
        value = "1,643.57";
        if (float.TryParse(value, out number))
            Console.WriteLine(number);
        else
            Console.WriteLine($"Unable to parse '{value}'.");

        // Parse a floating-point value with a currency symbol and a
        // thousands separator.
        value = "$1,643.57";
        if (float.TryParse(value, out number))
            Console.WriteLine(number);
        else
            Console.WriteLine($"Unable to parse '{value}'.");

        // Parse value in exponential notation.
        value = "-1.643e6";
        if (float.TryParse(value, out number))
            Console.WriteLine(number);
        else
            Console.WriteLine($"Unable to parse '{value}'.");

        // Parse a negative integer value.
        value = "-168934617882109132";
        if (float.TryParse(value, out number))
            Console.WriteLine(number);
        else
            Console.WriteLine($"Unable to parse '{value}'.");
        // The example displays the following output:
        //       1643.57
        //       Unable to parse '$1,643.57'.
        //       -164300
        //       -1.689346E+17
        // </Snippet1>
    }

    private static void TryParseWithConstraints()
    {
        // <Snippet2>
        string value;
        System.Globalization.NumberStyles style;
        System.Globalization.CultureInfo culture;
        float number;

        // Parse currency value using en-GB culture.
        value = "£1,097.63";
        style = System.Globalization.NumberStyles.Number |
                System.Globalization.NumberStyles.AllowCurrencySymbol;
        culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
        if (float.TryParse(value, style, culture, out number))
            Console.WriteLine($"Converted '{value}' to {number}.");
        else
            Console.WriteLine($"Unable to convert '{value}'.");

        value = "1345,978";
        style = System.Globalization.NumberStyles.AllowDecimalPoint;
        culture = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
        if (float.TryParse(value, style, culture, out number))
            Console.WriteLine($"Converted '{value}' to {number}.");
        else
            Console.WriteLine($"Unable to convert '{value}'.");

        value = "1.345,978";
        style = System.Globalization.NumberStyles.AllowDecimalPoint |
                System.Globalization.NumberStyles.AllowThousands;
        culture = System.Globalization.CultureInfo.CreateSpecificCulture("es-ES");
        if (float.TryParse(value, style, culture, out number))
            Console.WriteLine($"Converted '{value}' to {number}.");
        else
            Console.WriteLine($"Unable to convert '{value}'.");

        value = "1 345,978";
        if (float.TryParse(value, style, culture, out number))
            Console.WriteLine($"Converted '{value}' to {number}.");
        else
            Console.WriteLine($"Unable to convert '{value}'.");
        // The example displays the following output:
        //       Converted '£1,097.63' to 1097.63.
        //       Converted '1345,978' to 1345.978.
        //       Converted '1.345,978' to 1345.978.
        //       Unable to convert '1 345,978'.
        // </Snippet2>
    }
}

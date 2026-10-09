// <Snippet2>
using System;
using System.Globalization;

public class TryParseExactExample2
{
    public static void Run()
    {
        string intervalString, format;
        TimeSpan interval;
        CultureInfo culture = null;

        // Parse hour:minute value with custom format specifier.
        intervalString = "17:14";
        format = "h\\:mm";
        culture = CultureInfo.CurrentCulture;
        if (TimeSpan.TryParseExact(intervalString, format,
                                   culture, TimeSpanStyles.AssumeNegative, out interval))
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        else
            Console.WriteLine($"Unable to parse '{intervalString}' using format {format}");

        // Parse hour:minute:second value with "g" specifier.
        intervalString = "17:14:48";
        format = "g";
        culture = CultureInfo.InvariantCulture;
        if (TimeSpan.TryParseExact(intervalString, format,
                                   culture, TimeSpanStyles.AssumeNegative, out interval))
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        else
            Console.WriteLine($"Unable to parse '{intervalString}' using format {format}");

        // Parse hours:minute.second value with custom format specifier.
        intervalString = "17:14:48.153";
        format = @"h\:mm\:ss\.fff";
        culture = null;
        if (TimeSpan.TryParseExact(intervalString, format,
                                   culture, TimeSpanStyles.AssumeNegative, out interval))
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        else
            Console.WriteLine($"Unable to parse '{intervalString}' using format {format}");

        // Parse days:hours:minute.second value with "G" specifier
        // and current (en-US) culture.
        intervalString = "3:17:14:48.153";
        format = "G";
        culture = CultureInfo.CurrentCulture;
        if (TimeSpan.TryParseExact(intervalString, format,
                                   culture, TimeSpanStyles.AssumeNegative, out interval))
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        else
            Console.WriteLine($"Unable to parse '{intervalString}' using format {format}");

        // Parse days:hours:minute.second value with a custom format specifier.
        intervalString = "3:17:14:48.153";
        format = @"d\:hh\:mm\:ss\.fff";
        culture = null;
        if (TimeSpan.TryParseExact(intervalString, format,
                                   culture, TimeSpanStyles.AssumeNegative, out interval))
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        else
            Console.WriteLine($"Unable to parse '{intervalString}' using format {format}");

        // Parse days:hours:minute.second value with "G" specifier
        // and fr-FR culture.
        intervalString = "3:17:14:48,153";
        format = "G";
        culture = new("fr-FR");
        if (TimeSpan.TryParseExact(intervalString, format,
                                   culture, TimeSpanStyles.AssumeNegative, out interval))
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        else
            Console.WriteLine($"Unable to parse '{intervalString}' using format {format}");

        // Parse a single number using the "c" standard format string.
        intervalString = "12";
        format = "c";
        if (TimeSpan.TryParseExact(intervalString, format,
                                   null, TimeSpanStyles.AssumeNegative, out interval))
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        else
            Console.WriteLine($"Unable to parse '{intervalString}' using format {format}");

        // Parse a single number using the "%h" custom format string.
        format = "%h";
        if (TimeSpan.TryParseExact(intervalString, format,
                                   null, TimeSpanStyles.AssumeNegative, out interval))
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        else
            Console.WriteLine($"Unable to parse '{intervalString}' using format {format}");

        // Parse a single number using the "%s" custom format string.
        format = "%s";
        if (TimeSpan.TryParseExact(intervalString, format,
                                   null, TimeSpanStyles.AssumeNegative, out interval))
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        else
            Console.WriteLine($"Unable to parse '{intervalString}' using format {format}");
    }
}
// The example displays the following output:
//    '17:14' (h\:mm) --> -17:14:00
//    '17:14:48' (g) --> 17:14:48
//    '17:14:48.153' (h\:mm\:ss\.fff) --> -17:14:48.1530000
//    '3:17:14:48.153' (G) --> 3.17:14:48.1530000
//    '3:17:14:48.153' (d\:hh\:mm\:ss\.fff) --> -3.17:14:48.1530000
//    '3:17:14:48,153' (G) --> 3.17:14:48.1530000
//    '12' (c) --> 12.00:00:00
//    '12' (%h) --> -12:00:00
//    '12' (%s) --> -00:00:12
// </Snippet2>

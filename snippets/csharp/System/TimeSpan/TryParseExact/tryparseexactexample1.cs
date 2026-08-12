// <Snippet1>
using System;
using System.Globalization;

public class TryParseExactExample1
{
    public static void Run()
    {
        string intervalString, format;
        TimeSpan interval;
        CultureInfo culture;

        // Parse hour:minute value with "g" specifier current culture.
        intervalString = "17:14";
        format = "g";
        culture = CultureInfo.CurrentCulture;
        if (TimeSpan.TryParseExact(intervalString, format, culture, out interval))
            Console.WriteLine($"'{intervalString}' --> {interval}");
        else
            Console.WriteLine($"Unable to parse {intervalString}");

        // Parse hour:minute:second value with "G" specifier.
        intervalString = "17:14:48";
        format = "G";
        culture = CultureInfo.InvariantCulture;
        if (TimeSpan.TryParseExact(intervalString, format, culture, out interval))
            Console.WriteLine($"'{intervalString}' --> {interval}");
        else
            Console.WriteLine($"Unable to parse {intervalString}");

        // Parse hours:minute.second value with "G" specifier
        // and current (en-US) culture.
        intervalString = "17:14:48.153";
        format = "G";
        culture = CultureInfo.CurrentCulture;
        if (TimeSpan.TryParseExact(intervalString, format, culture, out interval))
            Console.WriteLine($"'{intervalString}' --> {interval}");
        else
            Console.WriteLine($"Unable to parse {intervalString}");

        // Parse days:hours:minute.second value with "G" specifier
        // and current (en-US) culture.
        intervalString = "3:17:14:48.153";
        format = "G";
        culture = CultureInfo.CurrentCulture;
        if (TimeSpan.TryParseExact(intervalString, format, culture, out interval))
            Console.WriteLine($"'{intervalString}' --> {interval}");
        else
            Console.WriteLine($"Unable to parse {intervalString}");

        // Parse days:hours:minute.second value with "G" specifier
        // and fr-FR culture.
        intervalString = "3:17:14:48.153";
        format = "G";
        culture = new("fr-FR");
        if (TimeSpan.TryParseExact(intervalString, format, culture, out interval))
            Console.WriteLine($"'{intervalString}' --> {interval}");
        else
            Console.WriteLine($"Unable to parse {intervalString}");

        // Parse days:hours:minute.second value with "G" specifier
        // and fr-FR culture.
        intervalString = "3:17:14:48,153";
        format = "G";
        if (TimeSpan.TryParseExact(intervalString, format, culture, out interval))
            Console.WriteLine($"'{intervalString}' --> {interval}");
        else
            Console.WriteLine($"Unable to parse {intervalString}");

        // Parse a single number using the "c" standard format string.
        intervalString = "12";
        format = "c";
        if (TimeSpan.TryParseExact(intervalString, format, null, out interval))
            Console.WriteLine($"'{intervalString}' --> {interval}");
        else
            Console.WriteLine($"Unable to parse {intervalString}");

        // Parse a single number using the "%h" custom format string.
        format = "%h";
        if (TimeSpan.TryParseExact(intervalString, format, null, out interval))
            Console.WriteLine($"'{intervalString}' --> {interval}");
        else
            Console.WriteLine($"Unable to parse {intervalString}");

        // Parse a single number using the "%s" custom format string.
        format = "%s";
        if (TimeSpan.TryParseExact(intervalString, format, null, out interval))
            Console.WriteLine($"'{intervalString}' --> {interval}");
        else
            Console.WriteLine($"Unable to parse {intervalString}");
    }
}
// The example displays the following output:
//       '17:14' --> 17:14:00
//       Unable to parse 17:14:48
//       Unable to parse 17:14:48.153
//       '3:17:14:48.153' --> 3.17:14:48.1530000
//       Unable to parse 3:17:14:48.153
//       '3:17:14:48,153' --> 3.17:14:48.1530000
//       '12' --> 12.00:00:00
//       '12' --> 12:00:00
//       '12' --> 00:00:12
// </Snippet1>

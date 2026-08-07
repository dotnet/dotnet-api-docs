// <Snippet2>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        string intervalString, format;
        TimeSpan interval;
        CultureInfo culture = null;

        // Parse hour:minute value with custom format specifier.
        intervalString = "17:14";
        format = "h\\:mm";
        culture = CultureInfo.CurrentCulture;
        try
        {
            interval = TimeSpan.ParseExact(intervalString, format,
                                           culture, TimeSpanStyles.AssumeNegative);
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{intervalString}': Bad Format for '{format}'");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{intervalString}': Overflow");
        }

        // Parse hour:minute:second value with "g" specifier.
        intervalString = "17:14:48";
        format = "g";
        culture = CultureInfo.InvariantCulture;
        try
        {
            interval = TimeSpan.ParseExact(intervalString, format,
                                           culture, TimeSpanStyles.AssumeNegative);
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{intervalString}': Bad Format for '{format}'");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{intervalString}': Overflow");
        }

        // Parse hours:minute.second value with custom format specifier.
        intervalString = "17:14:48.153";
        format = @"h\:mm\:ss\.fff";
        culture = null;
        try
        {
            interval = TimeSpan.ParseExact(intervalString, format,
                                           culture, TimeSpanStyles.AssumeNegative);
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{intervalString}': Bad Format for '{format}'");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{intervalString}': Overflow");
        }

        // Parse days:hours:minute.second value with "G" specifier
        // and current (en-US) culture.
        intervalString = "3:17:14:48.153";
        format = "G";
        culture = CultureInfo.CurrentCulture;
        try
        {
            interval = TimeSpan.ParseExact(intervalString, format,
                                           culture, TimeSpanStyles.AssumeNegative);
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{intervalString}': Bad Format for '{format}'");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{intervalString}': Overflow");
        }

        // Parse days:hours:minute.second value with a custom format specifier.
        intervalString = "3:17:14:48.153";
        format = @"d\:hh\:mm\:ss\.fff";
        culture = null;
        try
        {
            interval = TimeSpan.ParseExact(intervalString, format,
                                           culture, TimeSpanStyles.AssumeNegative);
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{intervalString}': Bad Format for '{format}'");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{intervalString}': Overflow");
        }

        // Parse days:hours:minute.second value with "G" specifier
        // and fr-FR culture.
        intervalString = "3:17:14:48,153";
        format = "G";
        culture = new("fr-FR");
        try
        {
            interval = TimeSpan.ParseExact(intervalString, format,
                                           culture, TimeSpanStyles.AssumeNegative);
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{intervalString}': Bad Format for '{format}'");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{intervalString}': Overflow");
        }

        // Parse a single number using the "c" standard format string.
        intervalString = "12";
        format = "c";
        try
        {
            interval = TimeSpan.ParseExact(intervalString, format,
                                           null, TimeSpanStyles.AssumeNegative);
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{intervalString}': Bad Format for '{format}'");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{intervalString}': Overflow");
        }

        // Parse a single number using the "%h" custom format string.
        format = "%h";
        try
        {
            interval = TimeSpan.ParseExact(intervalString, format,
                                           null, TimeSpanStyles.AssumeNegative);
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{intervalString}': Bad Format for '{format}'");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{intervalString}': Overflow");
        }

        // Parse a single number using the "%s" custom format string.
        format = "%s";
        try
        {
            interval = TimeSpan.ParseExact(intervalString, format,
                                           null, TimeSpanStyles.AssumeNegative);
            Console.WriteLine($"'{intervalString}' ({format}) --> {interval}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"'{intervalString}': Bad Format for '{format}'");
        }
        catch (OverflowException)
        {
            Console.WriteLine($"'{intervalString}': Overflow");
        }
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

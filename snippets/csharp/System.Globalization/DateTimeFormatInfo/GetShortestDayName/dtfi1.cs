using System;
using System.Globalization;

class Sample
{
    public static void Main()
    {
        //<snippet1>
        string[] myDateTimePatterns = ["MM/dd/yy", "MM/dd/yyyy"];

        // Get the en-US culture.
        CultureInfo ci = new("en-US");
        // Get the DateTimeFormatInfo for the en-US culture.
        DateTimeFormatInfo dtfi = ci.DateTimeFormat;

        // Display the effective culture.
        Console.WriteLine("This code example uses the {0} culture.", ci.Name);

        // Display the native calendar name.
        Console.WriteLine("\nNativeCalendarName...");
        Console.WriteLine($"\"{dtfi.NativeCalendarName}\"");

        // Display month genitive names.
        Console.WriteLine("\nMonthGenitiveNames...");
        foreach (string name in dtfi.MonthGenitiveNames)
        {
            Console.WriteLine($"\"{name}\"");
        }

        // Display abbreviated month genitive names.
        Console.WriteLine("\nAbbreviatedMonthGenitiveNames...");
        foreach (string name in dtfi.AbbreviatedMonthGenitiveNames)
        {
            Console.WriteLine($"\"{name}\"");
        }

        // Display shortest day names.
        Console.WriteLine("\nShortestDayNames...");
        foreach (string name in dtfi.ShortestDayNames)
        {
            Console.WriteLine($"\"{name}\"");
        }

        // Display shortest day name for a particular day of the week.
        Console.WriteLine("\nGetShortestDayName(DayOfWeek.Sunday)...");
        Console.WriteLine($"\"{dtfi.GetShortestDayName(DayOfWeek.Sunday)}\"");

        // Display the initial DateTime format patterns for the 'd' format specifier.
        Console.WriteLine("\nInitial DateTime format patterns for the 'd' format specifier...");
        foreach (string name in dtfi.GetAllDateTimePatterns('d'))
        {
            Console.WriteLine($"\"{name}\"");
        }

        // Change the initial DateTime format patterns for the 'd' DateTime format specifier.
        Console.WriteLine("\nChange the initial DateTime format patterns for the \n" +
                          "'d' format specifier to my format patterns...");
        dtfi.SetAllDateTimePatterns(myDateTimePatterns, 'd');

        // Display the new DateTime format patterns for the 'd' format specifier.
        Console.WriteLine("\nNew DateTime format patterns for the 'd' format specifier...");
        foreach (string name in dtfi.GetAllDateTimePatterns('d'))
        {
            Console.WriteLine($"\"{name}\"");
        }

        /*
        Output:

        This code example uses the en-US culture.

        NativeCalendarName...
        "Gregorian Calendar"

        MonthGenitiveNames...
        "January"
        "February"
        "March"
        "April"
        "May"
        "June"
        "July"
        "August"
        "September"
        "October"
        "November"
        "December"
        ""

        AbbreviatedMonthGenitiveNames...
        "Jan"
        "Feb"
        "Mar"
        "Apr"
        "May"
        "Jun"
        "Jul"
        "Aug"
        "Sep"
        "Oct"
        "Nov"
        "Dec"
        ""

        ShortestDayNames...
        "S"
        "M"
        "T"
        "W"
        "T"
        "F"
        "S"

        GetShortestDayName(DayOfWeek.Sunday)...
        "S"

        Initial DateTime format patterns for the 'd' format specifier...
        "M/d/yyyy"
        "MMM d, yyyy"
        "M/d/yy"

        Change the initial DateTime format patterns for the
        'd' format specifier to my format patterns...

        New DateTime format patterns for the 'd' format specifier...
        "MM/dd/yy"
        "MM/dd/yyyy"

        */
        //</snippet1>
    }
}

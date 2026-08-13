// <Snippet3>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        Console.WriteLine($"{"Date String",-18}{"Culture",-12}{"Result"}\n");

        string[] cultureNames = { "en-US", "ru-RU", "ja-JP" };
        string[] dateStrings = { "01/02/09", "2009/02/03",  "01/2009/03",
                               "01/02/2009", "21/02/09", "01/22/09",
                               "01/02/23" };
        // Iterate each culture name in the array.
        foreach (string cultureName in cultureNames)
        {
            CultureInfo culture = new(cultureName);

            // Parse each date using the designated culture.
            foreach (string dateStr in dateStrings)
            {
                DateTime dateTimeValue;
                try
                {
                    dateTimeValue = Convert.ToDateTime(dateStr, culture);
                    // Display the date and time in a fixed format.
                    Console.WriteLine($"{dateStr,-18}{cultureName,-12}{dateTimeValue:yyyy-MMM-dd}");
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{dateStr,-18}{cultureName,-12}{e.GetType().Name}");
                }
            }
            Console.WriteLine();
        }
    }
}
// </Snippet3>

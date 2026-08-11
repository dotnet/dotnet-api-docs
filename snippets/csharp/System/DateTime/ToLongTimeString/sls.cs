// <Snippet1>
using System;
using System.Threading;
using System.Globalization;

public class Sample
{
    public static void Main()
    {
        // Create an array of culture names.
        string[] names = { "en-US", "en-GB", "fr-FR", "de-DE" };
        // Initialize a DateTime object.
        DateTime dateValue = new(2013, 5, 28, 10, 30, 15);

        // Iterate the array of culture names.
        foreach (string name in names)
        {
            // Change the culture of the current thread.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(name);
            // Display the name of the current culture and the date.
            Console.WriteLine($"Current culture: {CultureInfo.CurrentCulture.Name}");
            Console.WriteLine($"Date: {dateValue:G}");

            // Display the long time pattern and the long time.
            Console.WriteLine($"Long time pattern: '{DateTimeFormatInfo.CurrentInfo.LongTimePattern}'");
            Console.WriteLine($"Long time with format string:     {dateValue:T}");
            Console.WriteLine($"Long time with ToLongTimeString:  {dateValue.ToLongTimeString()}\n");
        }
    }
}
// The example displays the following output:
//       Current culture: en-US
//       Date: 5/28/2013 10:30:15 AM
//       Long time pattern: 'h:mm:ss tt'
//       Long time with format string:     10:30:15 AM
//       Long time with ToLongTimeString:  10:30:15 AM
//
//       Current culture: en-GB
//       Date: 28/05/2013 10:30:15
//       Long time pattern: 'HH:mm:ss'
//       Long time with format string:     10:30:15
//       Long time with ToLongTimeString:  10:30:15
//
//       Current culture: fr-FR
//       Date: 28/05/2013 10:30:15
//       Long time pattern: 'HH:mm:ss'
//       Long time with format string:     10:30:15
//       Long time with ToLongTimeString:  10:30:15
//
//       Current culture: de-DE
//       Date: 28.05.2013 10:30:15
//       Long time pattern: 'HH:mm:ss'
//       Long time with format string:     10:30:15
//       Long time with ToLongTimeString:  10:30:15
// </Snippet1>

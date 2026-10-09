// <Snippet3>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
    public static void Main()
    {
        DateTimeOffset date1 = new(new DateTime(1550, 7, 21),
                                                  TimeSpan.Zero);
        CultureInfo dft;
        CultureInfo heIL = new("he-IL");
        heIL.DateTimeFormat.Calendar = new HebrewCalendar();

        // Change current culture to he-IL.
        dft = Thread.CurrentThread.CurrentCulture;
        Thread.CurrentThread.CurrentCulture = heIL;

        // Display the date using the current culture's calendar.
        try
        {
            Console.WriteLine(date1.ToString("G"));
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine($"{date1.ToString("d", CultureInfo.InvariantCulture)} is earlier than {heIL.DateTimeFormat.Calendar.MinSupportedDateTime.ToString("d", CultureInfo.InvariantCulture)} or later than {heIL.DateTimeFormat.Calendar.MaxSupportedDateTime.ToString("d", CultureInfo.InvariantCulture)}");
        }

        // Restore the default culture.
        Thread.CurrentThread.CurrentCulture = dft;
    }
}
// The example displays the following output:
//    07/21/1550 is earlier than 01/01/1583 or later than 09/29/2239
// </Snippet3>

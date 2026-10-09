// <Snippet4>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        CultureInfo arSA = new("ar-SA");
        arSA.DateTimeFormat.Calendar = new UmAlQuraCalendar();
        DateTimeOffset date1 = new(new DateTime(1890, 9, 10),
                                                  TimeSpan.Zero);

        try
        {
            Console.WriteLine(date1.ToString("d", arSA));
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine($"{date1:d} is earlier than {arSA.DateTimeFormat.Calendar.MinSupportedDateTime:d} or later than {arSA.DateTimeFormat.Calendar.MaxSupportedDateTime:d}");
        }
    }
}
// The example displays the following output:
//    9/10/1890 is earlier than 4/30/1900 or later than 5/13/2029
// </Snippet4>

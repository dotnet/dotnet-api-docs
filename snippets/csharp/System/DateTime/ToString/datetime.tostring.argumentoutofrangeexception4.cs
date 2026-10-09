// <Snippet4>
using System;
using System.Globalization;

public class Example4
{
    public static void Main()
    {
        CultureInfo arSA = new("ar-SA");
        arSA.DateTimeFormat.Calendar = new UmAlQuraCalendar();
        DateTime date1 = new(1890, 9, 10);

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

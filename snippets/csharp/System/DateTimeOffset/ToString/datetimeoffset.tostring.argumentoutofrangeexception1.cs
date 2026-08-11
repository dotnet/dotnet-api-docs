// <Snippet1>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        CultureInfo jaJP = new("ja-JP");
        jaJP.DateTimeFormat.Calendar = new JapaneseCalendar();
        DateTimeOffset date1 = new(new DateTime(1867, 1, 1),
                                                  TimeSpan.Zero);

        try
        {
            Console.WriteLine(date1.ToString(jaJP));
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine($"{date1:d} is earlier than {jaJP.DateTimeFormat.Calendar.MinSupportedDateTime:d} or later than {jaJP.DateTimeFormat.Calendar.MaxSupportedDateTime:d}");
        }
    }
}
// The example displays the following output:
//    1/1/1867 is earlier than 9/8/1868 or later than 12/31/9999
// </Snippet1>

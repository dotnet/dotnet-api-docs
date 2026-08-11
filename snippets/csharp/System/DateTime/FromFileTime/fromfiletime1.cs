// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        DateTime date1 = new(2010, 3, 14, 2, 30, 00);
        Console.WriteLine($"Invalid Time: {TimeZoneInfo.Local.IsInvalidTime(date1)}");
        long ft = date1.ToFileTime();
        DateTime date2 = DateTime.FromFileTime(ft);
        Console.WriteLine($"{date1} -> {date2}");
    }
}
// The example displays the following output:
//       Invalid Time: True
//       3/14/2010 2:30:00 AM -> 3/14/2010 3:30:00 AM
// </Snippet1>

// <Snippet2>
using System;

public struct TimeZoneTime
{
    public TimeZoneTime(DateTimeOffset dateTime, TimeZoneInfo timeZone)
    {
        DateTime = dateTime;
        TimeZone = timeZone;
    }

    public DateTimeOffset DateTime { get; }

    public TimeZoneInfo TimeZone { get; }
}

public class Example1
{
    public static void RunIt()
    {
        // Declare an array with two elements.
        TimeZoneTime[] timeZoneTimes = {
            new(DateTime.Now, TimeZoneInfo.Local),
            new(DateTime.Now, TimeZoneInfo.Utc)
        };
        foreach (var timeZoneTime in timeZoneTimes)
            Console.WriteLine("{0}: {1:G}",
                              timeZoneTime.TimeZone == null ? "<null>" : timeZoneTime.TimeZone.ToString(),
                              timeZoneTime.DateTime);
        Console.WriteLine();

        Array.Clear(timeZoneTimes, 1, 1);
        foreach (var timeZoneTime in timeZoneTimes)
            Console.WriteLine("{0}: {1:G}",
                              timeZoneTime.TimeZone == null ? "<null>" : timeZoneTime.TimeZone.ToString(),
                              timeZoneTime.DateTime);
    }
}

// The example displays the following output:
//       (UTC-08:00) Pacific Time (US & Canada): 1/20/2014 12:11:00 PM
//       UTC: 1/20/2014 12:11:00 PM
//
//       (UTC-08:00) Pacific Time (US & Canada): 1/20/2014 12:11:00 PM
//       <null>: 1/1/0001 12:00:00 AM
// </Snippet2>

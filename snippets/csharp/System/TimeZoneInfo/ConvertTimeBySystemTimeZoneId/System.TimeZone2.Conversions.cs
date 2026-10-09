using System;

[assembly: CLSCompliant(true)]
public class TimeZoneConversion
{
    public static void Main()
    {
        TimeZoneConversion tzc = new();
        Console.WriteLine("\nConvertToUtc:");
        tzc.ConvertToUtc();
        Console.WriteLine("\nConvertZonesToUtc:");
        tzc.ConvertZonesToUtc();
        Console.WriteLine();
        tzc.ConvertZonesById();
    }

    private void ConvertToUtc()
    {
        // <Snippet1>
        DateTime datNowLocal = DateTime.Now;
        Console.WriteLine($"Converting {datNowLocal}, Kind {datNowLocal.Kind}:");
        Console.WriteLine($"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc(datNowLocal)}, Kind {TimeZoneInfo.ConvertTimeToUtc(datNowLocal).Kind}");
        Console.WriteLine();

        DateTime datNowUtc = DateTime.UtcNow;
        Console.WriteLine($"Converting {datNowUtc}, Kind {datNowUtc.Kind}");
        Console.WriteLine($"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc(datNowUtc)}, Kind {TimeZoneInfo.ConvertTimeToUtc(datNowUtc).Kind}");
        Console.WriteLine();

        DateTime datNow = new(2007, 10, 26, 13, 32, 00);
        Console.WriteLine($"Converting {datNow}, Kind {datNow.Kind}");
        Console.WriteLine($"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc(datNow)}, Kind {TimeZoneInfo.ConvertTimeToUtc(datNow).Kind}");
        Console.WriteLine();

        DateTime datAmbiguous = new(2007, 11, 4, 1, 30, 00);
        Console.WriteLine($"Converting {datAmbiguous}, Kind {datAmbiguous.Kind}, Ambiguous {TimeZoneInfo.Local.IsAmbiguousTime(datAmbiguous)}");
        Console.WriteLine($"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc(datAmbiguous)}, Kind {TimeZoneInfo.ConvertTimeToUtc(datAmbiguous).Kind}");
        Console.WriteLine();

        DateTime datInvalid = new(2007, 3, 11, 02, 30, 00);
        Console.WriteLine($"Converting {datInvalid}, Kind {datInvalid.Kind}, Invalid {TimeZoneInfo.Local.IsInvalidTime(datInvalid)}");
        try
        {
            Console.WriteLine($"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc(datInvalid)}, Kind {TimeZoneInfo.ConvertTimeToUtc(datInvalid).Kind}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"   {e.GetType().Name}: Cannot convert {datInvalid} to UTC.");
        }
        Console.WriteLine();

        DateTime datNearMax = new(9999, 12, 31, 22, 00, 00);
        Console.WriteLine($"Converting {datNearMax}, Kind {datNearMax.Kind}");
        Console.WriteLine($"   ConvertTimeToUtc: {TimeZoneInfo.ConvertTimeToUtc(datNearMax)}, Kind {TimeZoneInfo.ConvertTimeToUtc(datNearMax).Kind}");
        Console.WriteLine();
        //
        // This example produces the following output if the local time zone
        // is Pacific Standard Time:
        //
        //    Converting 8/31/2007 2:26:28 PM, Kind Local:
        //       ConvertTimeToUtc: 8/31/2007 9:26:28 PM, Kind Utc
        //
        //    Converting 8/31/2007 9:26:28 PM, Kind Utc
        //       ConvertTimeToUtc: 8/31/2007 9:26:28 PM, Kind Utc
        //
        //    Converting 10/26/2007 1:32:00 PM, Kind Unspecified
        //       ConvertTimeToUtc: 10/26/2007 8:32:00 PM, Kind Utc
        //
        //    Converting 11/4/2007 1:30:00 AM, Kind Unspecified, Ambiguous True
        //       ConvertTimeToUtc: 11/4/2007 9:30:00 AM, Kind Utc
        //
        //    Converting 3/11/2007 2:30:00 AM, Kind Unspecified, Invalid True
        //       ArgumentException: Cannot convert 3/11/2007 2:30:00 AM to UTC.
        //
        //    Converting 12/31/9999 10:00:00 PM, Kind Unspecified
        //       ConvertTimeToUtc: 12/31/9999 11:59:59 PM, Kind Utc
        //
        // </Snippet1>
    }

    private void ConvertZonesToUtc()
    {
    }

    private void ConvertZonesById()
    {
        // <Snippet3>
        DateTime currentTime = DateTime.Now;
        Console.WriteLine("Current Times:");
        Console.WriteLine();
        Console.WriteLine($"Los Angeles: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Pacific Standard Time")}");
        Console.WriteLine($"Chicago: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")}");
        Console.WriteLine($"New York: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Eastern Standard Time")}");
        Console.WriteLine($"London: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "GMT Standard Time")}");
        Console.WriteLine($"Moscow: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Russian Standard Time")}");
        Console.WriteLine($"New Delhi: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "India Standard Time")}");
        Console.WriteLine($"Beijing: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "China Standard Time")}");
        Console.WriteLine($"Tokyo: {TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Tokyo Standard Time")}");
        // </Snippet3>
    }
}

// <Snippet6>
using System;
using System.Globalization;
using System.IO;
using System.Collections.ObjectModel;

public class GetSystemTimeZonesExample
{
    public static void Run()
    {
        const string OUTPUTFILENAME = @"C:\Temp\TimeZoneInfo.txt";

        DateTimeFormatInfo dateFormats = CultureInfo.CurrentCulture.DateTimeFormat;
        ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
        StreamWriter sw = new(OUTPUTFILENAME, false);

        foreach (TimeZoneInfo timeZone in timeZones)
        {
            bool hasDST = timeZone.SupportsDaylightSavingTime;
            TimeSpan offsetFromUtc = timeZone.BaseUtcOffset;
            TimeZoneInfo.AdjustmentRule[] adjustRules;
            string offsetString;

            sw.WriteLine($"ID: {timeZone.Id}");
            sw.WriteLine($"   Display Name: {timeZone.DisplayName,40}");
            sw.WriteLine($"   Standard Name: {timeZone.StandardName,39}");
            sw.Write($"   Daylight Name: {timeZone.DaylightName,39}");
            sw.Write(hasDST ? "   ***Has " : "   ***Does Not Have ");
            sw.WriteLine("Daylight Saving Time***");
            offsetString = $"{offsetFromUtc.Hours} hours, {offsetFromUtc.Minutes} minutes";
            sw.WriteLine($"   Offset from UTC: {offsetString,40}");
            adjustRules = timeZone.GetAdjustmentRules();
            sw.WriteLine($"   Number of adjustment rules: {adjustRules.Length,26}");
            if (adjustRules.Length > 0)
            {
                sw.WriteLine("   Adjustment Rules:");
                foreach (TimeZoneInfo.AdjustmentRule rule in adjustRules)
                {
                    TimeZoneInfo.TransitionTime transTimeStart = rule.DaylightTransitionStart;
                    TimeZoneInfo.TransitionTime transTimeEnd = rule.DaylightTransitionEnd;

                    sw.WriteLine($"      From {rule.DateStart} to {rule.DateEnd}");
                    sw.WriteLine($"      Delta: {rule.DaylightDelta}");
                    if (!transTimeStart.IsFixedDateRule)
                    {
                        sw.WriteLine($"      Begins at {transTimeStart.TimeOfDay:t} on {transTimeStart.DayOfWeek} of week {transTimeStart.Week} of {dateFormats.MonthNames[transTimeStart.Month - 1]}");
                        sw.WriteLine($"      Ends at {transTimeEnd.TimeOfDay:t} on {transTimeEnd.DayOfWeek} of week {transTimeEnd.Week} of {dateFormats.MonthNames[transTimeEnd.Month - 1]}");
                    }
                    else
                    {
                        sw.WriteLine($"      Begins at {transTimeStart.TimeOfDay:t} on {transTimeStart.Day} {dateFormats.MonthNames[transTimeStart.Month - 1]}");
                        sw.WriteLine($"      Ends at {transTimeEnd.TimeOfDay:t} on {transTimeEnd.Day} {dateFormats.MonthNames[transTimeEnd.Month - 1]}");
                    }
                }
            }
        }
        sw.Close();
    }
}
// </Snippet6>

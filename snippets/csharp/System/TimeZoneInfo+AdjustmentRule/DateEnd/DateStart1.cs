// <Snippet1>
using System;
using System.Collections.ObjectModel;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
        DateTimeFormatInfo dateInfo = CultureInfo.CurrentCulture.DateTimeFormat;

        foreach (var zone in timeZones)
        {
            Console.WriteLine($"{zone.StandardName} transition time information:");
            Console.WriteLine("   Time zone information: ");
            Console.WriteLine($"      Base UTC Offset: {zone.BaseUtcOffset}");
            Console.WriteLine($"      Supports DST: {zone.SupportsDaylightSavingTime}");

            TimeZoneInfo.AdjustmentRule[] adjustmentRules = zone.GetAdjustmentRules();

            // Indicate that time zone has no adjustment rules
            if (adjustmentRules.Length == 0)
            {
                Console.WriteLine("      No adjustment rules defined.");
            }
            else
            {
                Console.WriteLine($"      Adjustment Rules: {adjustmentRules.Length}");
                // Iterate adjustment rules
                foreach (var adjustmentRule in adjustmentRules)
                {
                    Console.WriteLine($"   Adjustment rule from {adjustmentRule.DateStart:d} to {adjustmentRule.DateEnd:d}:");
                    Console.WriteLine($"      Delta: {adjustmentRule.DaylightDelta}");
                    // Get start of transition
                    TimeZoneInfo.TransitionTime daylightStart = adjustmentRule.DaylightTransitionStart;
                    // Display information on floating date rule
                    if (!daylightStart.IsFixedDateRule)
                        Console.WriteLine($"      Begins at {daylightStart.TimeOfDay:t} on the {(WeekOfMonth)daylightStart.Week} {daylightStart.DayOfWeek} of {dateInfo.GetMonthName(daylightStart.Month)}");
                    // Display information on fixed date rule
                    else
                        Console.WriteLine($"      Begins at {daylightStart.TimeOfDay:t} on {dateInfo.GetMonthName(daylightStart.Month)} {daylightStart.Day}");

                    // Get end of transition.
                    TimeZoneInfo.TransitionTime daylightEnd = adjustmentRule.DaylightTransitionEnd;
                    // Display information on floating date rule.
                    if (!daylightEnd.IsFixedDateRule)
                        Console.WriteLine($"      Ends at {daylightEnd.TimeOfDay:t} on the {(WeekOfMonth)daylightEnd.Week} {daylightEnd.DayOfWeek} of {dateInfo.GetMonthName(daylightEnd.Month)}");
                    // Display information on fixed date rule.
                    else
                        Console.WriteLine($"      Ends at {daylightEnd.TimeOfDay:t} on {dateInfo.GetMonthName(daylightEnd.Month)} {daylightEnd.Day}");
                }
            }
        }
    }

    private enum WeekOfMonth
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Last = 5,
    }
}
// A portion of the output from the example might appear as follows:
//       Tonga Standard Time transition time information:
//          Time zone information:
//             Base UTC Offset: 13:00:00
//             Supports DST: False
//             No adjustment rules defined.
//       Samoa Standard Time transition time information:
//          Time zone information:
//             Base UTC Offset: 13:00:00
//             Supports DST: True
//             Adjustment Rules: 4
//          Adjustment rule from 1/1/0001 to 12/31/2009:
//             Delta: 00:00:00
//             Begins at 12:00 AM on January 1
//             Ends at 12:00 AM on January 1
//          Adjustment rule from 1/1/2010 to 12/31/2010:
//             Delta: 01:00:00
//             Begins at 11:59 PM on the Last Saturday of September
//             Ends at 12:00 AM on the First Friday of January
//          Adjustment rule from 1/1/2011 to 12/31/2011:
//             Delta: 01:00:00
//             Begins at 3:00 AM on the Fourth Saturday of September
//             Ends at 4:00 AM on the First Saturday of April
//          Adjustment rule from 1/1/2012 to 12/31/9999:
//             Delta: 01:00:00
//             Begins at 12:00 AM on the Last Sunday of September
//             Ends at 1:00 AM on the First Sunday of April
//       Line Islands Standard Time transition time information:
//          Time zone information:
//             Base UTC Offset: 14:00:00
//             Supports DST: False
//             No adjustment rules defined.
// </Snippet1>

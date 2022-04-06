// <Snippet1>
open System
open System.Globalization

let timeZones = TimeZoneInfo.GetSystemTimeZones()
let dateInfo = CultureInfo.CurrentCulture.DateTimeFormat

type WeekOfMonth = 
    | First = 1
    | Second = 2
    | Third = 3
    | Fourth = 4
    | Last = 5

for zone in timeZones do
    printfn $"{zone.StandardName} transition time information:"
    printfn "   Time zone information: "
    printfn $"      Base UTC Offset: {zone.BaseUtcOffset}"
    printfn $"      Supports DST: {zone.SupportsDaylightSavingTime}"

    let adjustmentRules= zone.GetAdjustmentRules()
    
    // Indicate that time zone has no adjustment rules
    if adjustmentRules.Length = 0 then
        printfn "      No adjustment rules defined."
    else
        printfn $"      Adjustment Rules: {adjustmentRules.Length}"
    // Iterate adjustment rules       
    for adjustmentRule in adjustmentRules do
        printfn $"   Adjustment rule from {adjustmentRule.DateStart:d} to {adjustmentRule.DateEnd:d}:"
        printfn $"      Delta: {adjustmentRule.DaylightDelta}"
        // Get start of transition
        let daylightStart = adjustmentRule.DaylightTransitionStart
        // Display information on floating date rule
        if not daylightStart.IsFixedDateRule then
            printfn $"      Begins at {daylightStart.TimeOfDay:t} on the {enum<WeekOfMonth> daylightStart.Week} {daylightStart.DayOfWeek} of {dateInfo.GetMonthName daylightStart.Month}"
        // Display information on fixed date rule 
        else
            printfn $"      Begins at {daylightStart.TimeOfDay:t} on {dateInfo.GetMonthName daylightStart.Month} {daylightStart.Day}"
        
        // Get end of transition.
        let daylightEnd = adjustmentRule.DaylightTransitionEnd
        // Display information on floating date rule.
        if not daylightEnd.IsFixedDateRule then
            printfn $"      Ends at {daylightEnd.TimeOfDay:t} on the {enum<WeekOfMonth> daylightEnd.Week} {daylightEnd.DayOfWeek} of {dateInfo.GetMonthName daylightEnd.Month}"
                            
        // Display information on fixed date rule.
        else
            printfn $"      Ends at {daylightEnd.TimeOfDay:t} on {dateInfo.GetMonthName daylightEnd.Month} {daylightEnd.Day}"

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
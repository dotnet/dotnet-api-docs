open System

// <Snippet1>
let displayDateWithTimeZoneName (date1: DateTime) (timeZone: TimeZoneInfo) =
    printfn $"The time is {date1:t} on {date1:d} {if timeZone.IsDaylightSavingTime date1 then timeZone.DaylightName else timeZone.StandardName}" 
// The example displays output similar to the following:
//    The time is 1:00 AM on 4/2/2006 Pacific Standard Time   
// </Snippet1>

// <Snippet2>
let unclearDate = DateTime(2007, 11, 4, 1, 30, 0)
// Test if time is ambiguous.
printfn $"""In the {TimeZoneInfo.Local.DisplayName}, {unclearDate} is {if TimeZoneInfo.Local.IsAmbiguousTime unclearDate then "" else "not "}ambiguous."""
// Test if time is DST.
printfn $"""In the {TimeZoneInfo.Local.DisplayName}, {unclearDate} is {if TimeZoneInfo.Local.IsDaylightSavingTime unclearDate then "" else "not "}daylight saving time.
"""
// Report time as DST if it is either ambiguous or DST.
if TimeZoneInfo.Local.IsAmbiguousTime unclearDate || TimeZoneInfo.Local.IsDaylightSavingTime unclearDate then
    printfn $"{unclearDate} may be daylight saving time in {TimeZoneInfo.Local.DisplayName}."

// The example displays the following output:
//    In the (GMT-08:00) Pacific Time (US & Canada), 11/4/2007 1:30:00 AM is ambiguous.
//    In the (GMT-08:00) Pacific Time (US & Canada), 11/4/2007 1:30:00 AM is not daylight saving time.
//    
//    11/4/2007 1:30:00 AM may be daylight saving time in (GMT-08:00) Pacific Time (US & Canada).
// </Snippet2>
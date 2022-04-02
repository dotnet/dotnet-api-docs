module Program

open System

// <Snippet1>
let showPossibleUtcTimes (ambiguousTime: DateTime) (timeZone: TimeZoneInfo) =
    // Determine if time is ambiguous in target time zone
    if not (timeZone.IsAmbiguousTime ambiguousTime) then
        printfn $"{ambiguousTime} is not ambiguous in time zone {timeZone.DisplayName}."
    else
        // Display time and its time zone (local, UTC, or indicated by timeZone argument)
        let originalTimeZoneName =
            match ambiguousTime.Kind with
            | DateTimeKind.Utc -> "UTC"
            | DateTimeKind.Local -> "local time"
            | _ -> timeZone.DisplayName

        printfn $"{ambiguousTime} {originalTimeZoneName} maps to the following possible times:"
        // Get ambiguous offsets 
        let offsets = timeZone.GetAmbiguousTimeOffsets ambiguousTime
        // Handle times not in time zone of timeZone argument
        // Local time where timeZone is not local zone
        let ambiguousTime =
            if (ambiguousTime.Kind = DateTimeKind.Local) && not (timeZone.Equals TimeZoneInfo.Local) then 
                TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Local, timeZone)
            // UTC time where timeZone is not UTC zone   
            elif (ambiguousTime.Kind = DateTimeKind.Utc) && not (timeZone.Equals TimeZoneInfo.Utc) then
                TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Utc, timeZone)
            else 
                ambiguousTime
        // Display each offset and its mapping to UTC
        for offset in offsets do
            if offset.Equals timeZone.BaseUtcOffset then
                printfn $"If {ambiguousTime} is {timeZone.StandardName}, {ambiguousTime - offset} UTC"
            else
                printfn $"If {ambiguousTime} is {timeZone.DaylightName}, {ambiguousTime - offset} UTC"
// </Snippet1>

// <Snippet2>
printfn ""
showPossibleUtcTimes(DateTime(2007, 11, 4, 1, 0, 0)) (TimeZoneInfo.FindSystemTimeZoneById "Central Standard Time")
printfn ""
showPossibleUtcTimes (DateTime(2007, 11, 4, 01, 00, 00, DateTimeKind.Local)) (TimeZoneInfo.FindSystemTimeZoneById "Central Standard Time")
printfn ""
showPossibleUtcTimes (DateTime(2007, 11, 4, 00, 00, 00, DateTimeKind.Local)) (TimeZoneInfo.FindSystemTimeZoneById "Central Standard Time")
printfn ""                     
showPossibleUtcTimes (DateTime(2007, 11, 4, 01, 00, 00, DateTimeKind.Unspecified)) (TimeZoneInfo.FindSystemTimeZoneById "Central Standard Time")
printfn ""
showPossibleUtcTimes (DateTime(2007, 11, 4, 07, 00, 00, DateTimeKind.Utc)) (TimeZoneInfo.FindSystemTimeZoneById "Central Standard Time")

// This example produces the following output if run in the Pacific time zone:
//
//    11/4/2007 1:00:00 AM (GMT-06:00) Central Time (US & Canada) maps to the following possible times:
//    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
//    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
//       
//    11/4/2007 1:00:00 AM Pacific Standard Time is not ambiguous in time zone (GMT-06:00) Central Time (US & Canada).
//     
//    11/4/2007 12:00:00 AM local time maps to the following possible times:
//    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
//    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
//    
//    11/4/2007 1:00:00 AM (GMT-06:00) Central Time (US & Canada) maps to the following possible times:
//    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
//    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
//       
//    11/4/2007 7:00:00 AM UTC maps to the following possible times:
//    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
//    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
//
// </Snippet2>                     

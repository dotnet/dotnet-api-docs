module converttime1

// <Snippet1>
open System

// Define times to be converted.
let times = 
    [| DateTime(2010, 1, 1, 0, 1, 0)
       DateTime(2010, 1, 1, 0, 1, 0, DateTimeKind.Utc)
       DateTime(2010, 1, 1, 0, 1, 0, DateTimeKind.Local)
       DateTime(2010, 11, 6, 23, 30, 0)
       DateTime(2010, 11, 7, 2, 30, 0) |]
                        
// Retrieve the time zone for Eastern Standard Time (U.S. and Canada).
try
    let est = TimeZoneInfo.FindSystemTimeZoneById "Eastern Standard Time"

    // Display the current time zone name.
    printfn $"Local time zone: {TimeZoneInfo.Local.DisplayName}\n"

    // Convert each time in the array.
    for timeToConvert in times do
        let targetTime = TimeZoneInfo.ConvertTime(timeToConvert, est)
        printfn $"Converted {timeToConvert} {timeToConvert.Kind} to {targetTime}."
with
| :? TimeZoneNotFoundException ->
    printfn "Unable to retrieve the Eastern Standard time zone."
| :? InvalidTimeZoneException ->
    printfn "Unable to retrieve the Eastern Standard time zone."
// The example displays the following output:
//    Local time zone: (GMT-08:00) Pacific Time (US & Canada)
//    
//    Converted 1/1/2010 12:01:00 AM Unspecified to 1/1/2010 3:01:00 AM.
//    Converted 1/1/2010 12:01:00 AM Utc to 12/31/2009 7:01:00 PM.
//    Converted 1/1/2010 12:01:00 AM Local to 1/1/2010 3:01:00 AM.
//    Converted 11/6/2010 11:30:00 PM Unspecified to 11/7/2010 1:30:00 AM.
//    Converted 11/7/2010 2:30:00 AM Unspecified to 11/7/2010 5:30:00 AM.
// </Snippet1>
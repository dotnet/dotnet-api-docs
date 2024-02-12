module converttime2
// <Snippet2>
open System

// Define times to be converted.
let time1 = DateTime(2010, 1, 1, 12, 1, 0)
let time2 = DateTime(2010, 11, 6, 23, 30, 0)
let times = 
    [| DateTimeOffset(time1, TimeZoneInfo.Local.GetUtcOffset time1)
       DateTimeOffset(time1, TimeSpan.Zero)
       DateTimeOffset(time2, TimeZoneInfo.Local.GetUtcOffset time2)
       DateTimeOffset(time2.AddHours 3, TimeZoneInfo.Local.GetUtcOffset(time2.AddHours 3)) |]
                        
// Retrieve the time zone for Eastern Standard Time (U.S. and Canada).
try
    let est = TimeZoneInfo.FindSystemTimeZoneById "Eastern Standard Time"

    // Display the current time zone name.
    printfn $"Local time zone: {TimeZoneInfo.Local.DisplayName}\n"

    // Convert each time in the array.
    for timeToConvert in times do
        let targetTime = TimeZoneInfo.ConvertTime(timeToConvert, est)
        printfn $"Converted {timeToConvert} to {targetTime}."
with
| :? TimeZoneNotFoundException ->
    printfn "Unable to retrieve the Eastern Standard time zone."
| :? InvalidTimeZoneException ->
    printfn "Unable to retrieve the Eastern Standard time zone."
// The example displays the following output:
//    Local time zone: (GMT-08:00) Pacific Time (US & Canada)
//    
//    Converted 1/1/2010 12:01:00 AM -08:00 to 1/1/2010 3:01:00 AM -05:00.
//    Converted 1/1/2010 12:01:00 AM +00:00 to 12/31/2009 7:01:00 PM -05:00.
//    Converted 11/6/2010 11:30:00 PM -07:00 to 11/7/2010 1:30:00 AM -05:00.
//    Converted 11/7/2010 2:30:00 AM -08:00 to 11/7/2010 5:30:00 AM -05:00.
// </Snippet2>
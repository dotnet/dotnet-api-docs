module clearstruct

// <Snippet2>
open System

[<Struct>]
type TimeZoneTime =
    { DateTime: DateTimeOffset
      TimeZone: TimeZoneInfo }

// Declare an array with two elements.
let timeZoneTimes = 
    [| { DateTime = DateTimeOffset.Now; TimeZone = TimeZoneInfo.Local }
       { DateTime = DateTimeOffset.Now; TimeZone = TimeZoneInfo.Local } |]

for timeZoneTime in timeZoneTimes do
    let tz = if isNull timeZoneTime.TimeZone then "<null>" else string timeZoneTime.TimeZone
    printfn $"{tz}: {timeZoneTime.DateTime:G}"
printfn ""

Array.Clear(timeZoneTimes, 1, 1)
for timeZoneTime in timeZoneTimes do
    let tz = if isNull timeZoneTime.TimeZone then "<null>" else string timeZoneTime.TimeZone
    printfn $"{tz}: {timeZoneTime.DateTime:G}"

// The example displays the following output:
//       (UTC-08:00) Pacific Time (US & Canada): 1/20/2014 12:11:00 PM
//       UTC: 1/20/2014 12:11:00 PM
//
//       (UTC-08:00) Pacific Time (US & Canada): 1/20/2014 12:11:00 PM
//       <null>: 1/1/0001 12:00:00 AM
// </Snippet2>
module Program

// <Snippet1>
open System

let showOffset (time: DateTime) (timeZone: TimeZoneInfo) =
    let convertedTime = 
        match time.Kind with
        | DateTimeKind.Local when not (timeZone.Equals TimeZoneInfo.Local) ->
            TimeZoneInfo.ConvertTime(time, TimeZoneInfo.Local, timeZone)
        | DateTimeKind.Utc when not (timeZone.Equals TimeZoneInfo.Utc) -> 
            TimeZoneInfo.ConvertTime(time, TimeZoneInfo.Utc, timeZone)         
        | _ -> time

    let offset = timeZone.GetUtcOffset time
    if time = convertedTime then
        printfn $"{time} {if timeZone.IsDaylightSavingTime time then timeZone.DaylightName else timeZone.StandardName} "
        printfn $"   It differs from UTC by {offset.Hours} hours, {offset.Minutes} minutes."
    else
        printfn $"""{time} {if time.Kind = DateTimeKind.Utc then "UTC" else TimeZoneInfo.Local.Id} """       
        printfn $"   converts to {convertedTime} {timeZone.Id}." 
        printfn $"   It differs from UTC by {offset.Hours} hours, {offset.Minutes} minutes."  
    printfn ""                                             

let cst = TimeZoneInfo.FindSystemTimeZoneById "Central Standard Time"

showOffset (DateTime(2006, 6, 12, 11, 0, 0)) TimeZoneInfo.Local
showOffset (DateTime(2007, 11, 4, 1, 0, 0)) TimeZoneInfo.Local
showOffset (DateTime(2006, 12, 10, 15, 0, 0)) TimeZoneInfo.Local
showOffset (DateTime(2007, 3, 11, 2, 30, 0)) TimeZoneInfo.Local
showOffset DateTime.UtcNow TimeZoneInfo.Local
showOffset (DateTime(2006, 6, 12, 11, 0, 0)) TimeZoneInfo.Utc
showOffset (DateTime(2007, 11, 4, 1, 0, 0)) TimeZoneInfo.Utc
showOffset (DateTime(2006, 12, 10, 3, 0, 0)) TimeZoneInfo.Utc
showOffset (DateTime(2007, 3, 11, 2, 30, 0)) TimeZoneInfo.Utc
showOffset DateTime.Now TimeZoneInfo.Utc
showOffset (DateTime(2006, 6, 12, 11, 0, 0)) cst
showOffset (DateTime(2007, 11, 4, 1, 0, 0)) cst
showOffset (DateTime(2006, 12, 10, 15, 0, 0)) cst
showOffset (DateTime(2007, 3, 11, 2, 30, 0, 0)) cst
showOffset (DateTime(2007, 11, 14, 00, 00, 00, DateTimeKind.Local)) cst

// The example produces the following output:
//
//       6/12/2006 11:00:00 AM Pacific Daylight Time 
//          It differs from UTC by -7 hours, 0 minutes.
//       
//       11/4/2007 1:00:00 AM Pacific Standard Time 
//          It differs from UTC by -8 hours, 0 minutes.
//       
//       12/10/2006 3:00:00 PM Pacific Standard Time 
//          It differs from UTC by -8 hours, 0 minutes.
//       
//       3/11/2007 2:30:00 AM Pacific Standard Time 
//          It differs from UTC by -8 hours, 0 minutes.
//       
//       2/2/2007 8:35:46 PM UTC 
//          converts to 2/2/2007 12:35:46 PM Pacific Standard Time.
//          It differs from UTC by -8 hours, 0 minutes.
//       
//       6/12/2006 11:00:00 AM UTC 
//          It differs from UTC by 0 hours, 0 minutes.
//       
//       11/4/2007 1:00:00 AM UTC 
//          It differs from UTC by 0 hours, 0 minutes.
//       
//       12/10/2006 3:00:00 AM UTC 
//          It differs from UTC by 0 hours, 0 minutes.
//       
//       3/11/2007 2:30:00 AM UTC 
//          It differs from UTC by 0 hours, 0 minutes.
//       
//       2/2/2007 12:35:46 PM Pacific Standard Time 
//          converts to 2/2/2007 8:35:46 PM UTC.
//          It differs from UTC by 0 hours, 0 minutes.
//       
//       6/12/2006 11:00:00 AM Central Daylight Time 
//          It differs from UTC by -5 hours, 0 minutes.
//       
//       11/4/2007 1:00:00 AM Central Standard Time 
//          It differs from UTC by -6 hours, 0 minutes.
//       
//       12/10/2006 3:00:00 PM Central Standard Time 
//          It differs from UTC by -6 hours, 0 minutes.
//       
//       3/11/2007 2:30:00 AM Central Standard Time 
//          It differs from UTC by -6 hours, 0 minutes.
//       
//       11/14/2007 12:00:00 AM Pacific Standard Time 
//          converts to 11/14/2007 2:00:00 AM Central Standard Time.
//          It differs from UTC by -6 hours, 0 minutes.
// </Snippet1>
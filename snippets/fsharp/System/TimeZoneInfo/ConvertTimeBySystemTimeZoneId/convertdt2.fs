module convertdt2

// <Snippet2>
open System

// Get time in local time zone 
let thisTime = DateTime.Now
printfn $"Time in {if TimeZoneInfo.Local.IsDaylightSavingTime thisTime then TimeZoneInfo.Local.DaylightName else TimeZoneInfo.Local.StandardName} zone: {thisTime}"
printfn $"   UTC Time: {TimeZoneInfo.ConvertTimeToUtc(thisTime, TimeZoneInfo.Local)}"
// Get Tokyo Standard Time zone
let tst = TimeZoneInfo.FindSystemTimeZoneById "Tokyo Standard Time"
let tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst)      
printfn $"Time in {if tst.IsDaylightSavingTime tstTime then tst.DaylightName else tst.StandardName} zone: {tstTime}"
printfn $"   UTC Time: {TimeZoneInfo.ConvertTimeToUtc(tstTime, tst)}"
// The example displays output like the following when run on a system in the
// U.S. Pacific Standard Time zone:
//       Time in Pacific Standard Time zone: 12/6/2013 10:57:51 AM
//          UTC Time: 12/6/2013 6:57:51 PM
//       Time in Tokyo Standard Time zone: 12/7/2013 3:57:51 AM
//          UTC Time: 12/6/2013 6:57:51 PM
// </Snippet2>
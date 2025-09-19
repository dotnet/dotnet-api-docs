// <Snippet1>
open System

let date1 = DateTime(2006, 3, 21, 2, 0, 0)

printfn $"{date1.ToUniversalTime()}"
printfn $"{TimeZoneInfo.ConvertTimeToUtc date1}"

let tz = TimeZoneInfo.FindSystemTimeZoneById "Pacific Standard Time"
printfn $"{TimeZoneInfo.ConvertTimeToUtc(date1, tz)}"

// The example displays the following output on Windows XP systems:
//       3/21/2006 9:00:00 AM
//       3/21/2006 9:00:00 AM
//       3/21/2006 10:00:00 AM
// </Snippet1>
// <Snippet1>
open System

let date1 = DateTime(2010, 3, 14, 2, 30, 0, DateTimeKind.Local)
printfn $"Invalid time: {TimeZoneInfo.Local.IsInvalidTime date1}"
let utcDate1 = date1.ToUniversalTime()
let date2 = utcDate1.ToLocalTime()
printfn $"{date1} --> {date2}"

// The example displays the following output:
//       Invalid time: True
//       3/14/2010 2:30:00 AM --> 3/14/2010 3:30:00 AM
// </Snippet1>
// <Snippet1>
open System

let date1 = DateTime(2010, 3, 14, 2, 30, 00)
printfn $"Invalid Time: {TimeZoneInfo.Local.IsInvalidTime date1}"

let ft = date1.ToFileTime()
let date2 = DateTime.FromFileTime ft
printfn $"{date1} -> {date2}"

// The example displays the following output:
//       Invalid Time: True
//       3/14/2010 2:30:00 AM -> 3/14/2010 3:30:00 AM
// </Snippet1>
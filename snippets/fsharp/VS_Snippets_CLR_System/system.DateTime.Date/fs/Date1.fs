// <Snippet1>
open System

let date1 = DateTime(2008, 6, 1, 7, 47, 0)
printfn $"{date1}"

// Get date-only portion of date, without its time.
let dateOnly = date1.Date
// Display date using short date string.
printfn $"{dateOnly:d}"
// Display date using 24-hour clock.
printfn $"{dateOnly:g}"
printfn $"""{dateOnly.ToString "MM/dd/yyyy HH:mm"}"""

// The example displays output like the following output:
//       6/1/2008 7:47:00 AM
//       6/1/2008
//       6/1/2008 12:00 AM
//       06/01/2008 00:00
// </Snippet1>
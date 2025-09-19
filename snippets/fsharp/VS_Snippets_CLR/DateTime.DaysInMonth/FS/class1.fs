//<Snippet1>
open System

let July = 7
let Feb = 2

let daysInJuly = DateTime.DaysInMonth(2001, July)
printfn $"{daysInJuly}"

// daysInFeb gets 28 because the year 1998 was not a leap year.
let daysInFeb = DateTime.DaysInMonth(1998, Feb)
printfn $"{daysInFeb}"

// daysInFebLeap gets 29 because the year 1996 was a leap year.
let daysInFebLeap = DateTime.DaysInMonth(1996, Feb)
printfn $"{daysInFebLeap}"

// The example displays the following output:
//       31
//       28
//       29
//</Snippet1>
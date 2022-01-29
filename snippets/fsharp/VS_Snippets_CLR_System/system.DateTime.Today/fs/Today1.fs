// <Snippet1>
open System

// Get the current date.
let thisDay = DateTime.Today
// Display the date in the default (general) format.
printfn $"{thisDay}\n"
// Display the date in a variety of formats.
printfn $"{thisDay:d}"
printfn $"{thisDay:D}"
printfn $"{thisDay:g}"

// The example displays output similar to the following:
//    5/3/2012 12:00:00 AM
//
//    5/3/2012
//    Thursday, May 03, 2012
//    5/3/2012 12:00 AM
// </Snippet1>
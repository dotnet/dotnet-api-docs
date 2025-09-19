// <Snippet1>
open System
open System.Globalization
open System.Threading

let dateToDisplay = DateTime(2009, 6, 1, 8, 42, 50)
let originalCulture = Thread.CurrentThread.CurrentCulture
// Change culture to en-US.
Thread.CurrentThread.CurrentCulture <- CultureInfo "en-US"
printfn "Displaying short date for {Thread.CurrentThread.CurrentCulture.Name} culture:"
printfn $"   {dateToDisplay.ToShortDateString()} (Short Date String)"

// Display using 'd' standard format specifier to illustrate it is
// identical to the string returned by ToShortDateString.
printfn $"   {dateToDisplay:d} ('d' standard format specifier)\n"

// Change culture to fr-FR.
Thread.CurrentThread.CurrentCulture <- CultureInfo "fr-FR"
printfn $"Displaying short date for {Thread.CurrentThread.CurrentCulture.Name} culture:"
printfn $"   {dateToDisplay.ToShortDateString()}\n"

// Change culture to nl-NL.
Thread.CurrentThread.CurrentCulture <- CultureInfo "nl-NL"
printfn $"Displaying short date for {Thread.CurrentThread.CurrentCulture.Name} culture:"
printfn $"   {dateToDisplay.ToShortDateString()}"

// Restore original culture.
Thread.CurrentThread.CurrentCulture <- originalCulture


// The example displays the following output:
//       Displaying short date for en-US culture:
//          6/1/2009 (Short Date String)
//          6/1/2009 ('d' standard format specifier)
//
//       Displaying short date for fr-FR culture:
//          01/06/2009
//
//       Displaying short date for nl-NL culture:
//          1-6-2009
// </Snippet1>
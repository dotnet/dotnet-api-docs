module Day2

// <Snippet2>
open System
open System.Globalization
open System.Threading

let originalCulture = Thread.CurrentThread.CurrentCulture

// Change current culture to ar-SA.
let ci = CultureInfo "ar-SA"
Thread.CurrentThread.CurrentCulture <- ci

let hijriDate = new DateTime(1430, 1, 17,
                        Thread.CurrentThread.CurrentCulture.Calendar);
// Display date (uses calendar of current culture by default).
printfn $"""{hijriDate.ToString "dd-MM-yyyy"}"""
// Displays 17-01-1430.

// Display day of 17th of Muharram
printfn $"{hijriDate.Day}"
// Displays 13 (corresponding day of January in Gregorian calendar).

// Display day of 17th of Muharram in Hijri calendar.
printfn $"{Thread.CurrentThread.CurrentCulture.Calendar.GetDayOfMonth hijriDate}"
// Displays 17.

Thread.CurrentThread.CurrentCulture <- originalCulture
// </Snippet2>
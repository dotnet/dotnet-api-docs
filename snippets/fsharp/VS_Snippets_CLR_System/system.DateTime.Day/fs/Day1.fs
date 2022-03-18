module Day1

open System
open System.Globalization

// <Snippet1>
// Return day of 1/13/2009.
let dateGregorian = DateTime(2009, 1, 13)
printfn $"{dateGregorian.Day}"
// Displays 13 (Gregorian day).

// Create date of 1/13/2009 using Hijri calendar.
let hijri = HijriCalendar()
let dateHijri = DateTime(1430, 1, 17, hijri)
// Return day of date created using Hijri calendar.
printfn $"{dateHijri.Day}"
// Displays 13 (Gregorian day).

// Display day of date in Hijri calendar.
printfn $"{hijri.GetDayOfMonth dateHijri}"
// Displays 17 (Hijri day).
// </Snippet1>
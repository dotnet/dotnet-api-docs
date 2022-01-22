module ctorexample2

// <Snippet2>
open System
open System.Globalization
open System.Text.RegularExpressions
open System.Threading

let getCalendarName (cal: Calendar) =
    Regex.Match(string cal, "\\.(\\w+)Calendar").Groups[1].Value

printfn "Using the Persian Calendar:"
let persian = PersianCalendar()
let date1 = DateTime(1389, 5, 27, persian)
printfn $"{date1}"
printfn $"{persian.GetMonth date1}/{persian.GetDayOfMonth date1}/{persian.GetYear date1}\n"

printfn "Using the Hijri Calendar:"
// Get current culture so it can later be restored.
let dftCulture = Thread.CurrentThread.CurrentCulture

// Define Hijri calendar.
let hijri = HijriCalendar()
// Make ar-SY the current culture and Hijri the current calendar.
Thread.CurrentThread.CurrentCulture <- CultureInfo "ar-SY"
let current = CultureInfo.CurrentCulture
current.DateTimeFormat.Calendar <- hijri

let dFormat =
    let dFormat = current.DateTimeFormat.ShortDatePattern
    // Ensure year is displayed as four digits.
    Regex.Replace(dFormat, "/yy$", "/yyyy")

current.DateTimeFormat.ShortDatePattern <- dFormat
let date2 = DateTime(1431, 9, 9, hijri)
printfn $"{current} culture using the {getCalendarName hijri} calendar: {date2:d}"

// Restore previous culture.
Thread.CurrentThread.CurrentCulture <- dftCulture
printfn $"{CultureInfo.CurrentCulture} culture using the {getCalendarName CultureInfo.CurrentCulture.Calendar} calendar: {date2:d}"


// The example displays the following output:
//       Using the Persian Calendar:
//       8/18/2010 12:00:00 AM
//       5/27/1389
//
//       Using the Hijri Calendar:
//       ar-SY culture using the Hijri calendar: 09/09/1431
//       en-US culture using the Gregorian calendar: 8/18/2010
// </Snippet2>
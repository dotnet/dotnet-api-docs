module ctorexample4

// <Snippet4>
open System
open System.Globalization
open System.Text.RegularExpressions
open System.Threading

let getCalendarName (cal: Calendar) =
    Regex.Match(string cal, "\\.(\\w+)Calendar").Groups[1].Value

printfn "Using the Persian Calendar:"
let persian = PersianCalendar()
let date1 = DateTime(1389, 5, 27, 16, 32, 0, persian)
printfn $"{date1}"
let sep = DateTimeFormatInfo.CurrentInfo.TimeSeparator
printfn $"{persian.GetMonth date1}/{persian.GetDayOfMonth date1}/{persian.GetYear date1} {persian.GetHour date1}{sep}%02i{persian.GetMinute date1}{sep}%02i{persian.GetSecond date1}\n"

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
let date2 = DateTime(1431, 9, 9, 16, 32, 18, hijri)
printfn $"{current} culture using the {getCalendarName hijri} calendar: {date2:g}"

// Restore previous culture.
Thread.CurrentThread.CurrentCulture <- dftCulture
printfn $"{CultureInfo.CurrentCulture} culture using the {getCalendarName CultureInfo.CurrentCulture.Calendar} calendar: {date2:g}"


// The example displays the following output:
//       Using the Persian Calendar:
//       8/18/2010 4:32:00 PM
//       5/27/1389 16:32:00
//
//       Using the Hijri Calendar:
//       ar-SY culture using the Hijri calendar: 09/09/1431 04:32 م
//       en-US culture using the Gregorian calendar: 8/18/2010 4:32 PM
// </Snippet4>
module ctorexample6

// <Snippet6>
open System
open System.Globalization
open System.Text.RegularExpressions
open System.Threading

let getCalendarName (cal: Calendar) =
      Regex.Match(string cal, "\\.(\\w+)Calendar").Groups[1].Value

printfn "Using the Persian Calendar:"
let persian = PersianCalendar()
let date1 = DateTime(1389, 5, 27, 16, 32, 18, 500, persian)
printfn $"""{date1.ToString("M/dd/yyyy h:mm:ss.fff tt")}"""
let sep = DateTimeFormatInfo.CurrentInfo.TimeSeparator
printfn $"{persian.GetMonth date1}/{persian.GetDayOfMonth date1}/{persian.GetYear date1} {persian.GetHour date1}{sep}%02i{persian.GetMinute date1}{sep}%02i{persian.GetSecond date1}.%.3f{persian.GetMilliseconds date1}\n"

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
    Regex.Replace(dFormat, "/yy$", "/yyyy") + " H:mm:ss.fff"

let fmtString = "{0} culture using the {1} calendar: {2:" + dFormat + "}"
let date2 = DateTime(1431, 9, 9, 16, 32, 18, 500, hijri)
Console.WriteLine(fmtString, current, getCalendarName hijri, date2)

// Restore previous culture.
Thread.CurrentThread.CurrentCulture <- dftCulture
let dFormat2 = DateTimeFormatInfo.CurrentInfo.ShortDatePattern + " H:mm:ss.fff"
let fmtString2 = "{0} culture using the {1} calendar: {2:" + dFormat + "}"
Console.WriteLine(fmtString2, CultureInfo.CurrentCulture, getCalendarName CultureInfo.CurrentCulture.Calendar, date2)


// The example displays the following output:
//       8/18/2010 4:32:18.500 PM
//       5/27/1389 16:32:18.500
//
//       Using the Hijri Calendar:
//       ar-SY culture using the Hijri calendar: 09/09/1431 16:32:18.500
//       en-US culture using the Gregorian calendar: 8/18/2010 16:32:18.500
// </Snippet6>
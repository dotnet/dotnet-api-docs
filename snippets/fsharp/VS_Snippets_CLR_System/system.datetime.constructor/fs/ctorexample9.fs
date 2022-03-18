module ctorexample9

// <Snippet9>
open System
open System.Globalization
open System.Text.RegularExpressions
open System.Threading

let getCalendarName (cal: Calendar) =
      Regex.Match(string cal, "\\.(\\w+)Calendar").Groups[1].Value

printfn "Using the Persian Calendar:"
let persian = PersianCalendar()
let date1 = DateTime(1389, 5, 27, 16, 32, 18, 500, persian, DateTimeKind.Local)
printfn $"""{date1.ToString "M/dd/yyyy h:mm:ss.fff tt"} {date1.Kind}"""
let sep = DateTimeFormatInfo.CurrentInfo.TimeSeparator
printfn $"{persian.GetMonth date1}/{persian.GetDayOfMonth date1}/{persian.GetYear date1} {persian.GetHour date1}{sep}{persian.GetMinute date1:D2}{sep}{persian.GetSecond date1:D2}.{persian.GetMilliseconds date1:G3} {date1.Kind}\n"

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

let fmtString = "{0} culture using the {1} calendar: {2:" + dFormat + "} {3}"
let date2 = DateTime(1431, 9, 9, 16, 32, 18, 500, hijri, DateTimeKind.Local)
Console.WriteLine(fmtString, current, getCalendarName hijri, date2, date2.Kind)

// Restore previous culture.
Thread.CurrentThread.CurrentCulture <- dftCulture
let dFormat2 = DateTimeFormatInfo.CurrentInfo.ShortDatePattern + " H:mm:ss.fff"
let fmtString2 = "{0} culture using the {1} calendar: {2:" + dFormat2 + "} {3}"
Console.WriteLine(fmtString2, CultureInfo.CurrentCulture, getCalendarName CultureInfo.CurrentCulture.Calendar, date2, date2.Kind)


// The example displays the following output:
//    Using the Persian Calendar:
//    8/18/2010 4:32:18.500 PM Local
//    5/27/1389 16:32:18.500 Local
//
//    Using the Hijri Calendar:
//    ar-SY culture using the Hijri calendar: 09/09/1431 16:32:18.500 Local
//    en-US culture using the Gregorian calendar: 8/18/2010 16:32:18.500 Local
// </Snippet9>
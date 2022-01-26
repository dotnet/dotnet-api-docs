// <Snippet1>
open System
open System.Globalization
open System.Threading

// Initialize date variable and display year
let date1 = DateTime(2008, 1, 1, 6, 32, 0)
printfn $"{date1.Year}"                    // Displays 2008

// Set culture to th-TH
Thread.CurrentThread.CurrentCulture <- CultureInfo "th-TH"
printfn $"{date1.Year}"                    // Displays 2008

// display year using current culture's calendar
let thaiCalendar = CultureInfo.CurrentCulture.Calendar
printfn $"{thaiCalendar.GetYear date1}"   // Displays 2551

// display year using Persian calendar
let persianCalendar = PersianCalendar()
printfn $"{persianCalendar.GetYear date1}" // Displays 1386
// </Snippet1>
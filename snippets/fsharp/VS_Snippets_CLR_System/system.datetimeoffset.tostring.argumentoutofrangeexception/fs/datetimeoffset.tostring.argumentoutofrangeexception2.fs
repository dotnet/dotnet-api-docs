module argumentoutofrangeexception2

// <Snippet2>
open System
open System.Globalization
open System.Threading

let date1 = DateTimeOffset(DateTime(550, 1, 1), TimeSpan.Zero)

let arSY = CultureInfo "ar-SY"
arSY.DateTimeFormat.Calendar <- HijriCalendar()

// Change current culture to ar-SY.
let dft = Thread.CurrentThread.CurrentCulture
Thread.CurrentThread.CurrentCulture <- arSY

// Display the date using the current culture's calendar.
try
    printfn $"{date1}"
with :? ArgumentOutOfRangeException ->
    printfn $"""{date1.ToString("d", CultureInfo.InvariantCulture)} is earlier than {arSY.DateTimeFormat.Calendar.MinSupportedDateTime.ToString("d", CultureInfo.InvariantCulture)} or later than {arSY.DateTimeFormat.Calendar.MaxSupportedDateTime.ToString("d", CultureInfo.InvariantCulture)}"""

// Restore the default culture.
Thread.CurrentThread.CurrentCulture <- dft

// The example displays the following output:
//    01/01/0550 is earlier than 07/18/0622 or later than 12/31/9999
// </Snippet2>
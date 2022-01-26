module argumentoutofrangeexception3

// <Snippet3>
open System
open System.Globalization
open System.Threading

let date1 = DateTime(1550, 7, 21)
let heIL = CultureInfo "he-IL"
heIL.DateTimeFormat.Calendar <- HebrewCalendar()

// Change current culture to he-IL.
let dft = Thread.CurrentThread.CurrentCulture
Thread.CurrentThread.CurrentCulture <- heIL

// Display the date using the current culture's calendar.
try
    printfn $"{date1:G}"
with :? ArgumentOutOfRangeException ->
    printfn $"""{date1.ToString("d", CultureInfo.InvariantCulture)} is earlier than {heIL.DateTimeFormat.Calendar.MinSupportedDateTime.ToString("d", CultureInfo.InvariantCulture)} or later than {heIL.DateTimeFormat.Calendar.MaxSupportedDateTime.ToString("d", CultureInfo.InvariantCulture)}"""

// Restore the default culture.
Thread.CurrentThread.CurrentCulture <- dft

// The example displays the following output:
//    07/21/1550 is earlier than 01/01/1583 or later than 09/29/2239
// </Snippet3>
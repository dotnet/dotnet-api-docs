module argumentoutofrangeexception4

// <Snippet4>
open System
open System.Globalization

let arSA = CultureInfo "ar-SA"
arSA.DateTimeFormat.Calendar <- UmAlQuraCalendar()
let date1 = DateTimeOffset(DateTime(1890, 9, 10), TimeSpan.Zero)

try
    printfn $"""{date1.ToString("d", arSA)}"""
with :? ArgumentOutOfRangeException ->
    printfn $"{date1:d} is earlier than {arSA.DateTimeFormat.Calendar.MinSupportedDateTime:d} or later than {arSA.DateTimeFormat.Calendar.MaxSupportedDateTime:d}"

// The example displays the following output:
//    9/10/1890 is earlier than 4/30/1900 or later than 11/16/2077
// </Snippet4>
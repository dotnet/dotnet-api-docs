module argumentoutofrangeexception4

// <Snippet4>
open System
open System.Globalization

let arSA = CultureInfo "ar-SA"
arSA.DateTimeFormat.Calendar <- UmAlQuraCalendar()
let date1 = DateTime(1890, 9, 10)

try
    date1.ToString("d", arSA)
    |> printfn "%s"
with :? ArgumentOutOfRangeException ->
    printfn $"{date1:d} is earlier than {arSA.DateTimeFormat.Calendar.MinSupportedDateTime:d} or later than {arSA.DateTimeFormat.Calendar.MaxSupportedDateTime:d}"
                     
// The example displays the following output:
//    9/10/1890 is earlier than 4/30/1900 or later than 5/13/2029
// </Snippet4>
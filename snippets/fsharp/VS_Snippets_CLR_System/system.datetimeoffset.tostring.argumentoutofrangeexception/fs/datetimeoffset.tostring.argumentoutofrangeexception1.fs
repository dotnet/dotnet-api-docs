module argumentoutofrangeexception1

// <Snippet1>
open System
open System.Globalization

let jaJP = CultureInfo "ja-JP"
jaJP.DateTimeFormat.Calendar <- JapaneseCalendar()
let date1 = DateTimeOffset(DateTime(1867, 1, 1), TimeSpan.Zero)

try
    printfn $"{date1.ToString jaJP}"
with :? ArgumentOutOfRangeException ->
    printfn $"{date1:d} is earlier than {jaJP.DateTimeFormat.Calendar.MinSupportedDateTime:d} or later than {jaJP.DateTimeFormat.Calendar.MaxSupportedDateTime:d}"

// The example displays the following output:
//    1/1/1867 is earlier than 9/8/1868 or later than 12/31/9999
// </Snippet1>
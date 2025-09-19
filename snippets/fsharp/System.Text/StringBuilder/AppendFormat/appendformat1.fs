module appendformat1
// <Snippet2>
open System
open System.Globalization
open System.Text

let sb = StringBuilder()
let value = 16.95m
let enGB = CultureInfo.CreateSpecificCulture "en-GB"
let dateToday = DateTime.Now
sb.AppendFormat(enGB, "Final Price: {0:C2}", value) |> ignore
sb.AppendLine() |> ignore
sb.AppendFormat(enGB, "Date and Time: {0:d} at {0:t}", dateToday) |> ignore
printfn $"{sb}"

// The example displays the following output:
//       Final Price: £16.95
//       Date and Time: 01/10/2014 at 10:22
// </Snippet2>

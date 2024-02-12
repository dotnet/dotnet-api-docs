module appendformat2
// <Snippet3>
open System
open System.Collections.Generic
open System.Globalization
open System.Text

let culture = CultureInfo "en-US"
let sb = StringBuilder()
let temperatureInfo = Dictionary<DateTime, Double>()
temperatureInfo.Add(DateTime(2010, 6, 1, 14, 0, 0), 87.46)
temperatureInfo.Add(DateTime(2010, 12, 1, 10, 0, 0), 36.81)

sb.AppendLine "Temperature Information:\n" |> ignore

for item in temperatureInfo do
    sb.AppendFormat(culture, "Temperature at {0,8:t} on {0,9:d}: {1,5:N1}°F\n", item.Key, item.Value)
    |> ignore

printfn $"{sb}"

// The example displays the following output:
//       Temperature Information:
//
//       Temperature at  2:00 PM on  6/1/2010:  87.5°F
//       Temperature at 10:00 AM on 12/1/2010:  36.8°F
// </Snippet3>

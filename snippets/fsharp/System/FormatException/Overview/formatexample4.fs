module formatexample4

// <Snippet6>
open System
open System.Collections.Generic

let temperatureInfo = Dictionary<DateTime, float>() 
temperatureInfo.Add(DateTime(2010, 6, 1, 14, 0, 0), 87.46)
temperatureInfo.Add(DateTime(2010, 12, 1, 10, 0, 0), 36.81)

printfn $"Temperature Information:\n"
for item in temperatureInfo do
   String.Format("Temperature at {0,8:t} on {0,9:d}: {1,5:N1}°F", item.Key, item.Value)
   |> printfn "%s"
// The example displays output like the following:
//       Temperature Information:
//       
//       Temperature at  2:00 PM on  6/1/2010:  87.5°F
//       Temperature at 10:00 AM on 12/1/2010:  36.8°F
// </Snippet6>
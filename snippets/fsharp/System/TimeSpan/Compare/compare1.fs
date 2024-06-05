// <Snippet1>
open System

// Define a time interval equal to two hours.
let baseInterval = TimeSpan(2, 0, 0)

// Define a list of time intervals to compare with
// the base interval.
let spans = 
    [ TimeSpan.FromSeconds -2.5
      TimeSpan.FromMinutes 20
      TimeSpan.FromHours 1 
      TimeSpan.FromMinutes 90
      baseInterval
      TimeSpan.FromDays 0.5 
      TimeSpan.FromDays 1 ]

// Compare the time intervals.
for span in spans do
    let result = TimeSpan.Compare(baseInterval, span)
    printfn $"""{baseInterval} {if result = 1 then ">" elif result = 0 then "=" else "<"} {span} (Compare returns {result})""" 

// The example displays the following output:
//       02:00:00 > -00:00:02.5000000 (Compare returns 1)
//       02:00:00 > 00:20:00 (Compare returns 1)
//       02:00:00 > 01:00:00 (Compare returns 1)
//       02:00:00 > 01:30:00 (Compare returns 1)
//       02:00:00 = 02:00:00 (Compare returns 0)
//       02:00:00 < 12:00:00 (Compare returns -1)
//       02:00:00 < 1.00:00:00 (Compare returns -1)
// </Snippet1>
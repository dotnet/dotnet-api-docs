// <Snippet1>
open System

let baseTimeSpan = TimeSpan(1, 12, 15, 16)

// Create a list of timespan intervals.
let intervals = 
    [ TimeSpan.FromDays 1.5 
      TimeSpan.FromHours 1.5 
      TimeSpan.FromMinutes 45
      TimeSpan.FromMilliseconds 505
      TimeSpan(1, 17, 32, 20) 
      TimeSpan(-8, 30, 0) ]

// Calculate a new time interval by adding each element to the base interval.
for interval in intervals do
   printfn $"""{baseTimeSpan,-10:g} {if interval < TimeSpan.Zero then "-" else "+"} {interval.ToString "%d\:hh\:mm\:ss\.ffff",15} = {baseTimeSpan.Add(interval).ToString "%d\:hh\:mm\:ss\.ffff"}""" 

// The example displays the following output:
//       1:12:15:16 + 1:12:00:00.0000 = 3:00:15:16.0000
//       1:12:15:16 + 0:01:30:00.0000 = 1:13:45:16.0000
//       1:12:15:16 + 0:00:45:00.0000 = 1:13:00:16.0000
//       1:12:15:16 + 0:00:00:00.5050 = 1:12:15:16.5050
//       1:12:15:16 + 1:17:32:20.0000 = 3:05:47:36.0000
//       1:12:15:16 - 0:07:30:00.0000 = 1:04:45:16.0000
// </Snippet1>
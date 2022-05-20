open System

// <Snippet1>
// Define an interval of 1 day, 15+ hours.
let interval = TimeSpan(1, 15, 42, 45, 750) 
printfn $"Value of TimeSpan: {interval}"

printfn $"{interval.TotalMinutes:N5} minutes, as follows:"
printfn $"   Minutes:      {interval.Days * 24 * 60 + interval.Hours * 60 + interval.Minutes,5}"
printfn $"   Seconds:      {interval.Seconds,5}" 
printfn $"   Milliseconds: {interval.Milliseconds,5}" 

// The example displays the following output:
//       Value of TimeSpan: 1.15:42:45.7500000
//       2,382.76250 minutes, as follows:
//          Minutes:       2382
//          Seconds:         45
//          Milliseconds:   750
// </Snippet1>
open System

// <Snippet1>
// Define an interval of 1 day, 15+ hours.
let interval = TimeSpan(1, 15, 42, 45, 750) 
printfn $"Value of TimeSpan: {interval}"

printfn $"{interval.TotalHours:N5} hours, as follows:"
printfn $"   Hours:        {interval.Days * 24 + interval.Hours,3}"
printfn $"   Minutes:      {interval.Minutes,3}" 
printfn $"   Seconds:      {interval.Seconds,3}" 
printfn $"   Milliseconds: {interval.Milliseconds,3}"

// The example displays the following output:
//       Value of TimeSpan: 1.15:42:45.7500000
//       39.71271 hours, as follows:
//          Hours:         39
//          Minutes:       42
//          Seconds:       45
//          Milliseconds: 750
// </Snippet1>
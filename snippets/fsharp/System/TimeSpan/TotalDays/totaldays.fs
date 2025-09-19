open System

// <Snippet1>
// Define an interval of 3 days, 16+ hours.
let interval = TimeSpan(3, 16, 42, 45, 750) 
printfn $"Value of TimeSpan: {interval}"
 
printfn $"{interval.TotalDays:N5} days, as follows:" 
printfn $"   Days:         {interval.Days,3}" 
printfn $"   Hours:        {interval.Hours,3}" 
printfn $"   Minutes:      {interval.Minutes,3}" 
printfn $"   Seconds:      {interval.Seconds,3}" 
printfn $"   Milliseconds: {interval.Milliseconds,3}" 

// The example displays the following output:
//       Value of TimeSpan: 3.16:42:45.7500000
//       3.69636 days, as follows:
//          Days:           3
//          Hours:         16
//          Minutes:       42
//          Seconds:       45
//          Milliseconds: 750
// </Snippet1>
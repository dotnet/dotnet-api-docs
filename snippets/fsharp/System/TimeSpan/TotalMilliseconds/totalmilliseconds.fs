open System

// <Snippet1>
// Define an interval of 1 day, 15+ hours.
let interval = TimeSpan(1, 15, 42, 45, 750) 
printfn $"Value of TimeSpan: {interval}" 

printfn $"There are {interval.TotalMilliseconds:N5} milliseconds, as follows:"
let nMilliseconds = int64 interval.Days * 24L * 60L * 60L * 1000L + 
                    int64 interval.Hours * 60L * 60L * 1000L + 
                    int64 interval.Minutes * 60L * 1000L + 
                    int64 interval.Seconds * 1000L + 
                    int64 interval.Milliseconds
printfn $"   Milliseconds:     {nMilliseconds,18:N0}" 
printfn $"   Ticks:            {nMilliseconds * 10000L - interval.Ticks,18:N0}"

// The example displays the following output:
//       Value of TimeSpan: 1.15:42:45.7500000
//       There are 142,965,750.00000 milliseconds, as follows:
//          Milliseconds:            142,965,750
//          Ticks:                             0
// </Snippet1>
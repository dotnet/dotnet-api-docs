module totalseconds

open System

// <Snippet1>
// Define an interval of 1 day, 15+ hours.
let interval = TimeSpan(1, 15, 42, 45, 750) 
printfn $"Value of TimeSpan: {interval}"

printfn $"{interval.TotalSeconds:N5} seconds, as follows:"
printfn $"   Seconds:      {interval.Days * 24 * 60 * 60 + 
                                             interval.Hours *60 * 60 + 
                                             interval.Minutes * 60 + 
                                             interval.Seconds,8:N0}"
printfn $"   Milliseconds: {interval.Milliseconds,8}"

// The example displays the following output:
//       Value of TimeSpan: 1.15:42:45.7500000
//       142,965.75000 seconds, as follows:
//          Seconds:       142,965
//          Milliseconds:      750
// </Snippet1>
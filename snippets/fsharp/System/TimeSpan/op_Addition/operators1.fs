module operators

// <Snippet1>
open System

let time1 = TimeSpan(1, 0, 0, 0)   // TimeSpan equivalent to 1 day.
let time2 = TimeSpan(12, 0, 0)     // TimeSpan equivalent to 1/2 day.
let time3 = time1 + time2          // Add the two time spans.

printfn $"  {time1,12}\n +  {time2,10}\n   {String('_', 10)}\n    {time3,10}" 
// The example displays the following output:
//           1.00:00:00
//        +    12:00:00
//          __________
//           1.12:00:00
// </Snippet1>
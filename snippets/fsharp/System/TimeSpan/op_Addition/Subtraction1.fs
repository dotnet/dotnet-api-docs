module Subtraction1

open System

// <Snippet2>
let startWork = TimeSpan(08,00,00)
let endWork = TimeSpan(18,30,00)
let lunchBreak = TimeSpan(1, 0, 0)
let breaks = TimeSpan(0, 30, 0)

printfn $"Length of work day: {endWork - startWork}"
printfn $"Actual time worked: {endWork - startWork - (lunchBreak + breaks)}"

// The example displays the following output:
//     Length of work day: 10:30:00
//     Actual time worked: 09:00:00
// </Snippet2>
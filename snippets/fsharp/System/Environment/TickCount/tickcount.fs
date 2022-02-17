//<snippet1>
// Sample for the Environment.TickCount property.

// TickCount cycles between Int32.MinValue, which is a negative
// number, and Int32.MaxValue once every 49.8 days. This sample
// removes the sign bit to yield a nonnegative number that cycles
// between zero and Int32.MaxValue once every 24.9 days.

open System

let result = Environment.TickCount &&& Int32.MaxValue
printfn $"TickCount: {result}"

// This example produces an output similar to the following:
//     TickCount: 101931139
//</snippet1>
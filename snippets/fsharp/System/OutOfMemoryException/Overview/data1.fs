module data1

// <Snippet3>
open System

let getData () =
    let rnd = Random()
    [|  for i = 1 to 200000000 do
            rnd.NextDouble()
            if i % 10000000 = 0 then
                printfn $"Retrieved {i:N0} items of data." |]
    
let getMean values =
    let sum = Array.sum values

    sum / float values.Length

let values = getData ()
// Compute mean.
printfn $"Sample mean: {getMean values}, N = {values.Length}"

// The example displays output like the following:
//    Retrieved 10,000,000 items of data.
//    Retrieved 20,000,000 items of data.
//    Retrieved 30,000,000 items of data.
//    Retrieved 40,000,000 items of data.
//    Retrieved 50,000,000 items of data.
//    Retrieved 60,000,000 items of data.
//    Retrieved 70,000,000 items of data.
//    Retrieved 80,000,000 items of data.
//    Retrieved 90,000,000 items of data.
//    Retrieved 100,000,000 items of data.
//    Retrieved 110,000,000 items of data.
//    Retrieved 120,000,000 items of data.
//    Retrieved 130,000,000 items of data.
//
//    Unhandled Exception: OutOfMemoryException.
// </Snippet3>
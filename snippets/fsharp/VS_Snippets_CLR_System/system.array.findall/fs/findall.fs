// <Snippet1>
open System

let getArray n lower upper =
    let rnd = Random()
    [|  for _ = 1 to n do 
            rnd.Next(lower, upper + 1) |]

// Get an array of n random integers.
let values = getArray 50 0 1000
let lBound = 300
let uBound = 600
let matchedItems = Array.FindAll(values, fun x -> x >= lBound && x <= uBound)

for i = 0 to matchedItems.Length - 1 do
    printf $"{matchedItems[i]}  "
    if (i + 1) % 12 = 0 then printfn ""

// The example displays output similar to the following:
//       542  398  356  351  348  301  562  599  575  400  569  306
//       535  416  393  385
// </Snippet1>

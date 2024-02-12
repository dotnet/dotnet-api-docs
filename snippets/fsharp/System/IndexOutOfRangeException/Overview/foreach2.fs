module foreach2

// <Snippet8>
open System

let populateArray items maxValue =
    let rnd = Random()
    [| for i = 0 to items - 1 do
        rnd.Next(0, maxValue + 1) |]

// Generate array of random values.
let values = populateArray 5 10
// Display each element in the array.
for value in values do
    printf $"{value}   "
    
// The example displays output like the following:
//        10   6   7   5   8
// </Snippet8>
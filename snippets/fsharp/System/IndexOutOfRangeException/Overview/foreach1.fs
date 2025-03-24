module foreach1

// <Snippet7>
open System

let populateArray items maxValue =
    let rnd = Random()
    [| for i = 0 to items - 1 do
        rnd.Next(0, maxValue + 1) |]

// Generate array of random values.
let values = populateArray 5 10
// Display each element in the array.
for value in values do
    printf $"{values[value]}   "

// The example displays output like the following:
//    6   4   4
//    Unhandled Exception: System.IndexOutOfRangeException:
//    Index was outside the bounds of the array.
//       at <StartupCode$fs>.main@()
// </Snippet7>
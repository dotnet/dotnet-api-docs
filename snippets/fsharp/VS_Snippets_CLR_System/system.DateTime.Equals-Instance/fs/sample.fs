//<snippet1>
open System

// Create some DateTime objects.
let one = DateTime.UtcNow

let two = DateTime.Now

let three = one

// Compare the DateTime objects and display the results.
let result = one.Equals two

printfn $"The result of comparing DateTime object one and two is: {result}."

let result2 = one.Equals three

printfn $"The result of comparing DateTime object one and three is: {result2}."

// This code example displays the following:
//
// The result of comparing DateTime object one and two is: False.
// The result of comparing DateTime object one and three is: True.
//</snippet1>
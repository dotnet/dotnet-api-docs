module writeline_boolean1

open System

// <Snippet4>
// Assign 10 random integers to an array.
let rnd = Random()
let numbers = 
    [ for _ = 0 to 9 do
        rnd.Next()]

// Determine whether the numbers are even or odd.
for number in numbers do
    let even = number % 2 = 0
    Console.WriteLine $"Is {number} even:"
    Console.WriteLine even
    Console.WriteLine()

// </Snippet4>
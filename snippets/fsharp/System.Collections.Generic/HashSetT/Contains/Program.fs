//<snippet01>
open System.Collections.Generic

//<snippet02>
let isOdd i = i % 2 = 1

let displaySet (set: HashSet<int>) =
    printf "{"

    for i in set do
        printf $" {i}"

    printfn " }"

let numbers = HashSet<int>()

for i in 1..20 do
    numbers.Add i |> ignore

// Display all the numbers in the hash table.
printf $"numbers contains {numbers.Count} elements: "
displaySet numbers

// Remove all odd numbers.
numbers.RemoveWhere isOdd |> ignore
printf $"numbers contains {numbers.Count} elements: "
displaySet numbers

// Check if the hash table contains 0 and, if so, remove it.
if numbers.Contains 0 then
    numbers.Remove 0 |> ignore

printf $"numbers contains {numbers.Count} elements: "
displaySet numbers
// This example displays the following output:
//    numbers contains 20 elements: { 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 }
//    numbers contains 10 elements: { 0 2 4 6 8 10 12 14 16 18 }
//    numbers contains 9 elements: { 2 4 6 8 10 12 14 16 18 }
// </snippet02>
// </snippet01>

module Program

//<snippet01>
open System.Collections.Generic

//<snippet02>
let displaySet (set: HashSet<int>) =
    printf "{"

    for i in set do
        printf $" {i}"

    printfn " }"

let lowNumbers = HashSet<int>()
let highNumbers = HashSet<int>()

for i = 0 to 5 do
    lowNumbers.Add i |> ignore

for i = 3 to 9 do
    highNumbers.Add i |> ignore

printf $"lowNumbers contains {lowNumbers.Count} elements: "
displaySet lowNumbers

printf $"highNumbers contains {highNumbers.Count} elements: "
displaySet highNumbers

printfn "highNumbers ExceptWith lowNumbers..."
highNumbers.ExceptWith(lowNumbers)

printf $"highNumbers contains {highNumbers.Count} elements: "
displaySet highNumbers
// This example provides output similar to the following:
//     lowNumbers contains 6 elements: { 0 1 2 3 4 5 }
//     highNumbers contains 7 elements: { 3 4 5 6 7 8 9 }
//     highNumbers ExceptWith lowNumbers...
//     highNumbers contains 4 elements: { 6 7 8 9 }
//</snippet02>
//</snippet01>

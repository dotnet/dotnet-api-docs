open System.Collections.Generic

//<snippet01>

let displaySet (collection: HashSet<int>) =
    printf "{"

    for i in collection do
        printf $" {i}"

    printfn " }"

//<snippet02>
//<snippet03>
let evenNumbers = HashSet<int>()
let oddNumbers = HashSet<int>()

for i = 0 to 4 do
    // Populate numbers with just even numbers.
    evenNumbers.Add(i * 2) |> ignore

    // Populate oddNumbers with just odd numbers.
    oddNumbers.Add(i * 2 + 1) |> ignore
//</snippet03>

printf $"evenNumbers contains {evenNumbers.Count} elements: "
displaySet evenNumbers

printf $"oddNumbers contains {oddNumbers.Count} elements: "
displaySet oddNumbers

// Create a new HashSet populated with even numbers.
let numbers = HashSet<int> evenNumbers
printfn "numbers UnionWith oddNumbers..."
numbers.UnionWith oddNumbers

printf $"numbers contains {numbers.Count} elements: "
displaySet numbers
//</snippet02>
// This example produces output similar to the following:
//    evenNumbers contains 5 elements: { 0 2 4 6 8 }
//    oddNumbers contains 5 elements: { 1 3 5 7 9 }
//    numbers UnionWith oddNumbers...
//    numbers contains 10 elements: { 0 2 4 6 8 1 3 5 7 9 }
//</snippet01>

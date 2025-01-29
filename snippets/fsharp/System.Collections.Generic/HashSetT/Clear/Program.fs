open System.Collections.Generic

//<snippet01>
let displaySet (set: HashSet<int>) =
    printf "{"

    for i in set do
        printf $" {i}"

    printfn " }"
// This example produces output similar to the following:
//     Numbers contains 10 elements: { 0 1 2 3 4 5 6 7 8 9 }
//     Numbers contains 0 elements: { }
//<snippet02>
let numbers = HashSet<int>()

for i = 0 to 9 do
    numbers.Add i |> ignore

printf $"Numbers contains {numbers.Count} elements: "
displaySet numbers

numbers.Clear()
numbers.TrimExcess()

printf $"Numbers contains {numbers.Count} elements: "
displaySet numbers
//</snippet02>
//</snippet01>

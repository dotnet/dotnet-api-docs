//<snippet01>
open System.Collections.Generic

//<snippet02>
let displaySet (set: HashSet<int>) =
    printf "{"

    for i in set do
        printf $" {i}"

    printfn " }"

let lowNumbers = HashSet<int>()
let allNumbers = HashSet<int>()

for i = 1 to 4 do
    lowNumbers.Add i |> ignore


for i = 0 to 9 do
    allNumbers.Add i |> ignore

printf $"lowNumbers contains {lowNumbers.Count} elements: "
displaySet lowNumbers

printf $"allNumbers contains {allNumbers.Count} elements: "
displaySet allNumbers

printfn $"lowNumbers overlaps allNumbers: {lowNumbers.Overlaps allNumbers}"

printfn $"allNumbers and lowNumbers are equal sets: {allNumbers.SetEquals lowNumbers}"

// Show the results of sub/superset testing
printfn $"lowNumbers is a subset of allNumbers: {lowNumbers.IsSubsetOf allNumbers}"
printfn $"allNumbers is a superset of lowNumbers: {allNumbers.IsSupersetOf lowNumbers}"
printfn $"lowNumbers is a proper subset of allNumbers: {lowNumbers.IsProperSubsetOf allNumbers}"
printfn $"allNumbers is a proper superset of lowNumbers: {allNumbers.IsProperSupersetOf lowNumbers}"

// Modify allNumbers to remove numbers that are not in lowNumbers.
allNumbers.IntersectWith lowNumbers
printf $"allNumbers contains {allNumbers.Count} elements: "
displaySet allNumbers

printfn $"allNumbers and lowNumbers are equal sets: {allNumbers.SetEquals lowNumbers}"

// Show the results of sub/superset testing with the modified set.
printfn $"lowNumbers is a subset of allNumbers: {lowNumbers.IsSubsetOf allNumbers}"
printfn $"allNumbers is a superset of lowNumbers: {allNumbers.IsSupersetOf lowNumbers}"
printfn $"lowNumbers is a proper subset of allNumbers: {lowNumbers.IsProperSubsetOf allNumbers}"
printfn $"allNumbers is a proper superset of lowNumbers: {allNumbers.IsProperSupersetOf lowNumbers}"
// This code example produces output similar to the following:
//     lowNumbers contains 4 elements: { 1 2 3 4 }
//     allNumbers contains 10 elements: { 0 1 2 3 4 5 6 7 8 9 }
//     lowNumbers overlaps allNumbers: True
//     allNumbers and lowNumbers are equal sets: False
//     lowNumbers is a subset of allNumbers: True
//     allNumbers is a superset of lowNumbers: True
//     lowNumbers is a proper subset of allNumbers: True
//     allNumbers is a proper superset of lowNumbers: True
//     allNumbers contains 4 elements: { 1 2 3 4 }
//     allNumbers and lowNumbers are equal sets: True
//     lowNumbers is a subset of allNumbers: True
//     allNumbers is a superset of lowNumbers: True
//     lowNumbers is a proper subset of allNumbers: False
//     allNumbers is a proper superset of lowNumbers: False
//</snippet02>
//</snippet01>
